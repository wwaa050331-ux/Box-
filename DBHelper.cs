using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace BOX.App
{
    public static class DBHelper
    {
        // 1. 오라클 데이터베이스 접속 정보
        private static readonly string HOST = "localhost";
        private static readonly string PORT = "1521";
        private static readonly string SERVICE_NAME = "xe";
        private static readonly string USER_ID = "hong1";
        private static readonly string PASSWORD = "1111";

        // 연결 문자열 자동 조합
        private static readonly string ConnectionString =
            $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={HOST})(PORT={PORT}))" +
            $"(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={SERVICE_NAME})));" +
            $"User Id={USER_ID};Password={PASSWORD};";

        /// <summary>
        /// 새로운 오라클 연결 객체를 반환합니다.
        /// </summary>
        public static OracleConnection GetConnection()
        {
            return new OracleConnection(ConnectionString);
        }

        /// <summary>
        /// SELECT 쿼리를 실행하여 결과 데이터를 DataTable로 반환합니다. (DataGridView 바인딩용)
        /// </summary>
        public static DataTable ExecuteQuery(string sql, OracleParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

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
