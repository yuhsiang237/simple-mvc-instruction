using Dapper;
using System.Data.SqlClient;
using WebMVCApplication.Models;

namespace WebMVCApplication.DataAccess
{
    public class TodoManageRepository
    {
        private readonly string _connectString = @"Server=.\SQLExpress;Database=TodoDB;Trusted_Connection=True;ConnectRetryCount=0";

        /// <summary>
        /// 查詢user列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserDto>> GetUserListAsync()
        {
            using (var conn = new SqlConnection(_connectString))
            {
                var result = await conn.QueryAsync<UserDto>("SELECT * FROM Users");
                return result;
            }
        }

        /// <summary>
        /// 查詢todo列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TodoDto>> GetTodoListAsync()
        {
            using (var conn = new SqlConnection(_connectString))
            {
                var result = await conn.QueryAsync<TodoDto>(
                    @"SELECT
                    Todos.*,
                    USERS.username
                    FROM Todos
                    LEFT JOIN USERS ON USERS.ID = TODOS.USERID");
                return result;
            }
        }

        /// <summary>
        /// 查詢todo列表
        /// </summary>
        /// <returns></returns>
        public async Task<int> UpdateTodoListAsync(int id, bool isComplete)
        {
            using (var conn = new SqlConnection(_connectString))
            {
                var result = await conn.ExecuteAsync(
                    @"UPDATE TODOS 
                     SET
                     [IsComplete] = @IsComplete
                    WHERE Id = @Id
                    ",new
                    {
                        IsComplete = isComplete,
                        Id = id,
                    });
                return result;
            }
        }
    }
}
