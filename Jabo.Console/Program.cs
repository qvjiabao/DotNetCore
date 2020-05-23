using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Jabo.Dapper;
using StackExchange.Redis;


namespace Jabo.Console
{
    class Program
    {
        private static IDbConnection GetOpenConnection()
        {
            IDbConnection connection;
            connection = new SqlConnection(@"server=.;database=YX_DataBase;uid=sa;pwd=1qaz@WSX");
            DataBase.SetDialect(DataBase.Dialect.SQLServer);
            connection.Open();
            return connection;
        }

        static void Main(string[] args)
        {
            using (var connection = GetOpenConnection())
            {
                var id = connection.Insert(new MenuModel { Title = "TestInsertWithSpecifiedTableName", Href = "k10" });

                System.Console.WriteLine(id);
            }
            System.Console.ReadKey();
        }
    }
}
