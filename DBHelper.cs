using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace BOX.App
{
    public static class DBHelper
    {
        // ==========================================
        // 1. 오라클 데이터베이스 접속 정보 설정
        // ==========================================
        private static readonly string HOST = "localhost";        // 로컬 오라클 접속
        private static readonly string PORT = "1521";             // 오라클 기본 포트
        private static readonly string SERVICE_NAME = "xe";       // 11g 기본 SID (XE)
        private static readonly string USER_ID = "box";           // 변경된 사용자 ID
        private static readonly string PASSWORD = "1111";         // 비밀번호

        // 연결 문자열 자동 조합
        private static readonly string ConnectionString =
            $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={HOST})(PORT={PORT}))" +
            $"(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={SERVICE_NAME})));" +
            $"User Id={USER_ID};Password={PASSWORD};";

        /// <summary>
        /// 새로운 오라클 연결(OracleConnection) 인스턴스를 반환합니다.
        /// </summary>
        public static OracleConnection GetConnection()
        {
            return new OracleConnection(ConnectionString);
        }

        /// <summary>
        /// SELECT 쿼리를 실행하여 결과 데이터를 DataTable로 반환합니다. (DataGridView 바인딩용)
        /// </summary>
        /// <param name="sql">실행할 SELECT SQL문</param>
        /// <param name="parameters">바인딩할 파라미터 배열 (선택)</param>
        public static DataTable ExecuteQuery(string sql, OracleParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            using (OracleConnection conn = GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.BindByName = true; // 파라미터명 기준 바인딩

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        conn.Open();
                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DB Error - ExecuteQuery]: {ex.Message}");
                        throw;
                    }
                }
            }

            return dt;
        }

        /// <summary>
        /// INSERT, UPDATE, DELETE 쿼리를 실행하고 영향을 받은 행 수를 반환합니다.
        /// </summary>
        /// <param name="sql">실행할 DML SQL문</param>
        /// <param name="parameters">바인딩할 파라미터 배열 (선택)</param>
        /// <returns>영향을 받은 행(row) 수</returns>
        public static int ExecuteNonQuery(string sql, OracleParameter[] parameters = null)
        {
            int affectedRows = 0;

            using (OracleConnection conn = GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.BindByName = true;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        conn.Open();
                        affectedRows = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DB Error - ExecuteNonQuery]: {ex.Message}");
                        throw;
                    }
                }
            }

            return affectedRows;
        }

        /// <summary>
        /// 단일 값(COUNT, 특정 코드값 등)을 조회할 때 사용합니다.
        /// </summary>
        /// <param name="sql">실행할 SELECT 집계 SQL문</param>
        /// <param name="parameters">바인딩할 파라미터 배열 (선택)</param>
        /// <returns>단일 조회 값 (object)</returns>
        public static object ExecuteScalar(string sql, OracleParameter[] parameters = null)
        {
            object result = null;

            using (OracleConnection conn = GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.BindByName = true;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        conn.Open();
                        result = cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"[DB Error - ExecuteScalar]: {ex.Message}");
                        throw;
                    }
                }
            }

            return result;
        }
    }
}
