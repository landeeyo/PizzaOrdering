using System.ComponentModel.DataAnnotations.Schema;

namespace Landeeyo.Pizza.Common.Models.AccountControl
{
    /// <summary>
    /// User model
    /// </summary>
    [Table("tblUser")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
