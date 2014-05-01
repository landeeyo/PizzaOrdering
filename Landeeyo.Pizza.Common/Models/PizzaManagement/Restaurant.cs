using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.Common.Models.PizzaManagement
{
    /// <summary>
    /// Restaurant model
    /// </summary>
    [Table("Restaurant")]
    public class Restaurant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RestaurantID { get; set; }

        [Required]
        [MaxLength(25), MinLength(3)] 
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
