
namespace Landeeyo.Pizza.Common.Models.AccountControl
{
    /// <summary>
    /// User model
    /// </summary>
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
