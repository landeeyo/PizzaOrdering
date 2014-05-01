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
    /// Pizza model
    /// </summary>
    [Table("Pizza")]
    public class Pizza
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PizzaID { get; set; }

        [Required]
        [MaxLength(25), MinLength(3)] 
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }

        public int RestaurantID { get; set; }
        [Required]
        [ForeignKey("RestaurantID")]        
        public Restaurant Restaurant { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
