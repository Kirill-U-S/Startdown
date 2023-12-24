using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Startdown.DB;
using Startdown.Models;
using System.Data.SqlClient;

namespace Startdown.Controllers
{
    public class CatalogController : Controller
    {
        // GET: CatalogController]
        List<Book> books = new List<Book>();
        public ActionResult Index()
        {
            string connstr = "Data Source=DESKTOP-UIR8C5V;Initial Catalog=StartDown_DB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                books = new List<Book>();
                string query = "select [dbo].[Books].[Id], [dbo].[Books].[Title], [dbo].[Books].[Author] from [dbo].[Books]";
                SqlCommand command = new SqlCommand(query, conn);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    string author = reader.GetString(2);

                    Book book = new Book(id, title, author);
                    books = books.Append(book).ToList();
                }
                conn.Close();
            }
            return View(books);
        }


        public IActionResult ButClick(int bookId)
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
                //начинаем чудо
                //настраиваем связь
                string connstr = "Data Source=DESKTOP-UIR8C5V;Initial Catalog=StartDown_DB;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();
                    ////пишем мегазапрос
                    string query = "INSERT INTO [dbo].[Order] (ID_User, Data, ID_Book, Status) " +
                                   $"VALUES ('{id}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{bookId}', 'в корзине')";
                    //и жесточайшим образом производим его тотальное повсеместное неотвратимое исполнение
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return RedirectToAction("Index");
        }
        // GET: CatalogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatalogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogController/Create
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

        // GET: CatalogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatalogController/Edit/5
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

        // GET: CatalogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatalogController/Delete/5
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
