using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using System.Data.SqlClient;

namespace Startdown.Controllers
{
    public class DeleteAccountController : Controller
    {
        // GET: DeleteAccountController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult DeleteAcc()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                TempData["Message"] = $"Авторизуйтесь или зарегистрируйтесь";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //считали id пользователя
                int id = 0;
                id = int.Parse(HttpContext.Session.GetString("id"));

                string query1 = "DELETE FROM [dbo].[Order]" +
                    $"WHERE[dbo].[Order].[ID_User] = {id}";
                string query2 = "DELETE FROM [dbo].[User]" +
                    $"WHERE[dbo].[User].[ID] = {id}";
                //открываем соединение
                string connstr = "Data Source=DESKTOP-UIR8C5V;Initial Catalog=StartDown_DB;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();
                    //выполняем 1 запрос
                    SqlCommand cmd = new SqlCommand(query1, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    //выполняем 2 запрос
                    SqlCommand cmd1 = new SqlCommand(query2, conn);
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: DeleteAccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeleteAccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeleteAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeleteAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeleteAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeleteAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeleteAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
