using Esemka.Models;

namespace Esemka.API.Controllers
{
    public static class GlobalData
    {
        public static User? loggedInUser { get; set; } = null;
    }
}
