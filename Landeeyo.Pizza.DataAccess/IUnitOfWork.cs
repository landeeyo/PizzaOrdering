using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public interface IUnitOfWork
    {
        DbContext Context { get; set; }
        DbTransaction Transaction { get; set; }
        void Commit();
        void Dispose();
    }
}
