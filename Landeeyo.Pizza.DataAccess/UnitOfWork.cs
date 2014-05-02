using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.DataAccessLayer
{
    //Vide: http://www.codeproject.com/Articles/243914/Entity-Framework-context-per-request
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public DbContext Context { get; set; }
        public DbTransaction Transaction { get; set; }

        public void Commit()
        {
            if (Context != null)
            {
                Context.SaveChanges();
                Transaction.Commit();
                Context.Database.Connection.Close();
            }
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Database.Connection.Close();
                Transaction.Dispose();
                Transaction = null;
                Context.Dispose();
                Context = null;
            }
        }
    }
}
