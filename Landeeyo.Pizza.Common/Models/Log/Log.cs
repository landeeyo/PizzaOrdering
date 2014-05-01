using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.Common.Models.Log
{
    /// <summary>
    /// Log model
    /// </summary>
    [Table("Log")]
    public class Log
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int LogID { get; set; }
        public DateTime OcurrenceDateTime { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public string Class { get; set; }
        public string Source { get; set; }
        public string CompleteInfo { get; set; }
    }
}
