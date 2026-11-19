using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace BOX.App
{
    public class DBClass
    {
        public OracleDataAdapter DBAdapter { get; set; }
        public DataSet DS { get; set; }
        public int SelectedLogId { get; set; }

        public void DB_ObjCreate()
        {
            DS = new DataSet();
        }

        public void DB_Open()
        {
            // 오라클 연결 문자열 (계정 환경에 맞게 수정 가능)
            string connectionString = "User Id=hong1; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
            string commandString = "SELECT * FROM SystemLogs ORDER BY log_id DESC";

            DBAdapter = new OracleDataAdapter(commandString, connectionString);
        }
    }
}