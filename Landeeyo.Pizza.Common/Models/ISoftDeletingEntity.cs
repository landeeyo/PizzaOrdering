using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.Common.Models
{
    public interface ISoftDeletingEntity
    {
        [DataType(DataType.DateTime)]
        DateTime? CreateDate { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? DeactivationDate { get; set; }
    }
}
