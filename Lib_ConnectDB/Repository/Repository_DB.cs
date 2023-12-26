using MySql.Data.MySqlClient;
using Lib_ConnectDB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Lib_ConnectDB.Models;
namespace Lib_ConnectDB.Repository
{
    public class Repository_DB: IRepository
    {
        public db_Context sxktctx { get; set; }
        public Database Db { get; set; }
 
        public Repository_DB()
        {
            
            _config _config = JsonConvert.DeserializeObject<_config>(File.ReadAllText("connectdb.json"));            
            MySqlConnection connection = new MySqlConnection(_config._config_db.sxkt);
            //int timeOut= connection.ConnectionTimeout;
            connection.Open();
           
            try
            {
                this.sxktctx = new db_Context(connection, false);

                // Interception/SQL logging
                this.sxktctx.Database.Log = (string message) => { Console.WriteLine(message); };

                this.Db = this.sxktctx.Database;

            }
            catch
            {
               
            }




        }
        public ConnectionState getConnectState()
        {
            return Db.Connection.State;
        }
        public IEnumerable<T> ExecuteSqlQuery<T>(string query)
        {
            try
            {
                IEnumerable<T> result = Db.SqlQuery<T>(query);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public IEnumerable<T> ExecuteStoreProceduce<T>(string storeProceduce, Dictionary<string, string> parameters)
        {
            string query = "call " + storeProceduce + "(";
            if (parameters != null)
            {
               
                foreach (KeyValuePair<string, string> par in parameters)
                {
                    if (parameters.LastOrDefault().Key == par.Key)
                        query += "'" + par.Value + "'";
                    else
                        query += "'" + par.Value + "',";
                }
            }
            
            query += ")";
            IEnumerable<T> result = ExecuteSqlQuery<T>(query);
            return result;
        }

        public IEnumerable<T> ExecuteStoreProceduce<T>(string storeProceduce)
        {
            string query = "call " + storeProceduce;
            IEnumerable<T> result = ExecuteSqlQuery<T>(query);
            return result;
        }

        public bool ExecuteSqlCommand(string storeProceduce, Dictionary<string, string> parameters)
        {
            string query = "call " + storeProceduce + " (";
            if (parameters != null)
            {
                
                foreach (KeyValuePair<string, string> par in parameters)
                {
                    if (parameters.LastOrDefault().Key == par.Key)
                        query += "'" + par.Value + "'";
                    else
                        query += "'" + par.Value + "',";
                }
            }
            query += ")";
            int result = Db.ExecuteSqlCommand(query);
            return result >= 1;
        }
        public bool ExecuteSqlQuery_Basic(string query)
        {
            try
            {
                int result = Db.ExecuteSqlCommand(query);
                return result >= 1;
            }
            catch
            {
                return false;
            }


        }
        public void Dispose()
        {
            try
            {
                Db.Connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
