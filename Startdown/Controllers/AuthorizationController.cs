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
                    //Пишем SQL запрос на вытягивание id
                    string queryrem = "select [dbo].[User].[id] from [dbo].[User]" +
                    $"where [dbo].[User].[Login] = '{Login}' and [dbo].[User].[Password] = '{Password}'";

                    //Выполняем запрос
                    SqlCommand cmdrem = new SqlCommand(queryrem, conn);
                    var reader = cmdrem.ExecuteReader();
                    
                    //Выполняем считывание+запоминаем
                    int id = 0;
                    if (reader.Read())
                        id = reader.GetInt32(0);
                    else
                    {
                        TempData["Message"] = "id не был обработан";
                        conn.Close();
                        return RedirectToAction("Index", "Authorization");
                    }

                    //настраиваем сессию
                    conn.Close();
                    HttpContext.Session.SetString("id", id.ToString());

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
