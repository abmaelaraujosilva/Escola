using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Escola.DataSource
{
    public class SqlDB : IConnection
    {
        SqlConnection _con;
        SqlCommand _cmd;
        SqlDataReader _reader;
        public SqlDB()
        {
            _con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL"].ConnectionString);
        }
        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                _con.Open();
                _cmd = new SqlCommand(sql, _con);
                _cmd.ExecuteReader();
                return true;
            }
            catch (SqlException err)
            {
                return false;
            }
            finally
            {
                if (_con.State == ConnectionState.Open)
                    _con.Close();
            }
        }

        public DataTable List(string sql)
        {
            try
            {
                _con.Open();
                _cmd = new SqlCommand(sql, _con);
                _reader = _cmd.ExecuteReader();
                DataTable DT = new DataTable();
                DT.Load(_reader);
                return DT;
            }
            catch (Exception)
            {
                return new DataTable();
            }
            finally
            {
                if (_con.State == ConnectionState.Open)
                    _con.Close();
            }
        }
    }
}