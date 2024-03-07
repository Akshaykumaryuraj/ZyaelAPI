using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using static Azure.Core.HttpHeader;

namespace DAL
{
    public class SqlDAL
    {
        public static string DefaultConnectionString = common.contrainingString;
        public string ConnectionString;
        protected SqlConnection _connection;

        protected SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = GetConnection();
                return _connection;
            }
            set { _connection = value; }
        }


        public static SqlConnection GetDefaultConnection()
        {
            return new SqlConnection(DefaultConnectionString);
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString ?? DefaultConnectionString);
        }

        public SqlDAL()
        {
            ConnectionString = DefaultConnectionString;
        }

        public SqlDAL(String connectionString)
        {
            ConnectionString = connectionString;
        }


    }
}
