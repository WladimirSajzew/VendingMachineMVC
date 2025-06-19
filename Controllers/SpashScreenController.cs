using Microsoft.AspNetCore.Mvc;

namespace VendingMachineMVC.Controllers
{
    public class SpashScreenController : Controller
    {
        // 
        // GET: /HelloWorld/
        public string Index()
        {
            return "Spashscreen: gleich geht's los!";
        }
        // 
        // GET: /HelloWorld/Welcome/ 
        public string Welcome()
        {
            return "Willkommen";
        }
    }
}
