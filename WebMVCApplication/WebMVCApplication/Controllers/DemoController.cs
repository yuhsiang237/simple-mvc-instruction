using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Transactions;
using WebMVCApplication.DataAccess;
using WebMVCApplication.ViewModels;

namespace WebMVCApplication.Controllers
{
    public class DemoController : Controller
    {
        private readonly TodoManageRepository _todoManageRepository;
        private readonly JsonSerializerOptions _JSONOptions;
        public DemoController(TodoManageRepository todoManageRepository)
        {
            _todoManageRepository = todoManageRepository;
            _JSONOptions = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }

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
       
        #region Dapper 操作範例

        public IActionResult DapperDemo()
        {
            return View();
        }
        /// <summary>
        /// Dapper查詢操作
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetDapperDataAsync()
        {
            var result1 = await _todoManageRepository.GetUserListAsync();
            var result2 = await _todoManageRepository.GetTodoListAsync();

            return new JsonResult(new
            {
                result1,
                result2
            }, _JSONOptions);
        }

        /// <summary>
        /// Dapper更新操作
        /// https://localhost:7298/demo/UpdateDapperDataAsync?id=3&iscomplete=true
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isComplete"></param>
        /// <returns></returns>
        [HttpGet("demo/UpdateDapperDataAsync")]
        public async Task<JsonResult> UpdateDapperDataAsync(int id, bool isComplete)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var result1 = await _todoManageRepository.UpdateTodoListAsync(id, isComplete);
            var result2 = await _todoManageRepository.GetTodoListAsync();
            scope.Complete();

            return new JsonResult(new
            {
                effectCount = result1,
                result2
            }, _JSONOptions);
        }
        #endregion Dapper 操作範例
    }
}
