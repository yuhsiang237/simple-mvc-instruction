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

        /// <summary>
        /// 三種頁面傳值示範
        /// </summary>
        /// <returns></returns>
        public IActionResult ValuePassDemo()
        {
            ViewBag.DemoModel1 = new
            {
                Game = "隻狼"
            };
            ViewData["DemoModel2"] = new GameViewData
            {
                Game = "血源詛咒"

            };

            var demoModel3 = new ValuePassDemoViewModel
            {
                Company = "FromSoftware",
                Games = new List<string>
                {
                    "黑暗靈魂",
                    "黑暗靈魂III",
                }
            };

            return View(demoModel3);
        }
    }
}
