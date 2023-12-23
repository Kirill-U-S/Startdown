using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Startdown.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index() //при переходе по /Autorization
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

                string query = $"INSERT INTO [dbo].[User] (Login, Password, ID_Order) VALUES ('{Login}', '{Password}', 1)";
                SqlCommand command = new SqlCommand(query, conn);

                command.ExecuteNonQuery();
                conn.Close();
            }
            return RedirectToAction();
        }
    }
}
