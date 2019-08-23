using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.DbRepositories.Interceptors
{
    class MyCommandInterceptor : IDbCommandInterceptor
    {
        private readonly IReadOnlyCollection<string> tables;

        public MyCommandInterceptor(IReadOnlyCollection<string> tables)
        {
            this.tables = tables;
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogInfo(command.CommandType.ToString(), command.CommandText);
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            LogInfo(command.CommandType.ToString(), command.CommandText);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            LogInfo(command.CommandType.ToString(), command.CommandText);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            foreach (var table in tables)
            {
                if (command.CommandText.Contains(table))
                {
                    command.CommandText = command.CommandText.Replace(table, $"{table}_2019");
                }

            }

            LogInfo(command.CommandType.ToString(), command.CommandText);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogInfo(command.CommandType.ToString(), command.CommandText);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            LogInfo(command.CommandType.ToString(), command.CommandText);
        }

        private void LogInfo(string command, string commandText)
        {

            //if (commandText.Contains("Vehicles"))
            //{
            //    commandText = commandText.Replace("Vehicles", "Vehicles_2019");
            //}

            Console.WriteLine($"{command} -> {commandText}");
        }
    }
}
