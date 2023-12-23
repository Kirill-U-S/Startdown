using Microsoft.AspNetCore.Mvc;
using Startdown.Models;
using System.Data.SqlClient;

namespace Startdown.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index() //при переходе по /Authorization
        {
            return View();
        }

        [HttpPost]
        public IActionResult AuthPage(string Login, string Password)
        {
            string connstr = "Data Source=DESKTOP-UIR8C5V;Initial Catalog=StartDown_DB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                string query = "select COUNT(*) from [dbo].[User]" +
                    $"where [dbo].[User].[Login] = '{Login}' and [dbo].[User].[Password] = '{Password}'";
                
                SqlCommand command = new SqlCommand(query, conn);
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    conn.Close();
                    return RedirectToAction("Index", "MainPage");
                }
                else
                {
                    TempData["Message"] = "Логин или пароль не найдены";
                    conn.Close();
                    return RedirectToAction("Index", "Authorization");
                }
            }
        }
    }
}
