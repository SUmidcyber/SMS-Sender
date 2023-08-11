using Microsoft.AspNetCore.Mvc;
using WinFormSmsApi.Models;

namespace SmsSender.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Random rnd = new Random();
            var model = rnd.Next(1000, 10000);
                
            return View(model);
        }

        public IActionResult Send(string phoneNumber)
        {

            SmsServices smsServices = new SmsServices();

            Random rnd = new Random();
            var model = rnd.Next(1000, 10000);

            var res = smsServices.SmsSender(phoneNumber, model.ToString());

            if (res)
            {
                ModelState.AddModelError("successful process", "done");
                return View("Index");
            }

            ModelState.AddModelError("", "unsuccessful process");
            return View("Index");


        }
    }
}
