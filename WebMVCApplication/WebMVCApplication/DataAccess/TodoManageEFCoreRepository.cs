using Microsoft.EntityFrameworkCore;
using WebMVCApplication.Models.EFCoreModels;

namespace WebMVCApplication.DataAccess
{
    public class TodoManageEFCoreRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoManageEFCoreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 查詢user列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserEFModel>> GetUserListAsync()
        {
            var result = await _context.Users.ToListAsync();
            return result;
        }

        /// <summary>
        /// 查詢todo列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TodoWithUserEFModel>> GetTodoListAsync()
        {
            var result = await (from todos in _context.Todos
                         join users in _context.Users
                         on todos.UserId equals users.Id into tu
                         from rs in tu.DefaultIfEmpty()
                         select new TodoWithUserEFModel
                         {
                             Id = todos.Id,
                             Name = todos.Name,
                             IsComplete = todos.IsComplete,
                             UserId = rs.Id,
                             UserName = rs.UserName
                         }).ToListAsync();
            
            return result;
        }

        /// <summary>
        /// 更新todo列表
        /// </summary>
        /// <returns></returns>
        public async Task<int> UpdateTodoListAsync(int id, bool isComplete)
        {
            var todo =await _context.Todos.FindAsync(id);
            if(todo != null)
            {
                todo.IsComplete = isComplete;
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
