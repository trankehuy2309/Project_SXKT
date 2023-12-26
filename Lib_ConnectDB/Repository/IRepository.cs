using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib_ConnectDB.Repository
{
    public interface IRepository
    {
        IEnumerable<T> ExecuteSqlQuery<T>(string query);
        IEnumerable<T> ExecuteStoreProceduce<T>(string storeProceduce, Dictionary<string, string> parameters);
        IEnumerable<T> ExecuteStoreProceduce<T>(string storeProceduce);
        bool ExecuteSqlCommand(string query, Dictionary<string, string> parameters);
        public bool ExecuteSqlQuery_Basic(string query);
        void Dispose();
    }
}
