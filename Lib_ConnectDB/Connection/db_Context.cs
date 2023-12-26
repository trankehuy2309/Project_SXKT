using MySql.Data.EntityFramework;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_ConnectDB.Connection
{

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class db_Context : DbContext
    {
        public db_Context() : base() { }
        public ObjectContext ObjectContext()
        {
            return ((IObjectContextAdapter)this).ObjectContext;
        }
        public db_Context(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
