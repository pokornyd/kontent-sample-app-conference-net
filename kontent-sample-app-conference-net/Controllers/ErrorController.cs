using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kontent_sample_app_conference_net.Controllers
{
    public class ErrorController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/Error/{statusCode}")]
        public ViewResult Status(int statusCode)
        {
            if (statusCode == StatusCodes.Status404NotFound)
            {
                return View("~/Views/Error/NotFound.cshtml");
            }
            else
            {
                return View("~/Views/Error/GeneralError.cshtml");
            }
        }
    }
}
