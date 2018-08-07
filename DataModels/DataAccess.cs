using System;
using Dapper;
using MySql.Data.MySqlClient;

namespace Uiprogramming
{
    public class DataAccess
    {
        public void RecordStartTime(int transaction_id, DateTime start_time, string activity)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionStringHelper.CnnVal("GotyotimeDB")))
            {
                DynamicParameters param = new DynamicParameters();
                PersonDataModel Person = new PersonDataModel { Transaction_id = transaction_id, Start_time = start_time, Activity = activity };
                param.Add("transactionid", Person.Transaction_id);
                param.Add("starttime", Person.Start_time);
                param.Add("activity", Person.Activity);
                connection.Execute("Start_Time_Insert", param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
