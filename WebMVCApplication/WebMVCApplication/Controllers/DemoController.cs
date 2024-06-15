using Microsoft.AspNetCore.Mvc;
using WebMVCApplication.ViewModels;

namespace WebMVCApplication.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult UserIntro()
        {
            var nameCardViewModel = new NameCardViewModel
            {
                Name = "王小名",
                Email = "xd123@gmail.com",
                Address = "高雄市XXX區"
            };
            ViewBag.NameCardData = nameCardViewModel;

            return View();
        }

    }
}
