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
                //решаем проверить а нет ли уже книги в заказах
                int count = 0;
                string connstr = "Data Source=DESKTOP-UIR8C5V;Initial Catalog=StartDown_DB;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();
                    string query = "select COUNT(*) from [dbo].[Order]" +
                        $"where [dbo].[Order].[ID_User] = {id} and [dbo].[Order].[ID_Book] = {bookId}";

                    SqlCommand command = new SqlCommand(query, conn);
                    count = (int)command.ExecuteScalar();
                    conn.Close();
                }
                if (count < 1)
                {
                    //начинаем чудо
                    //настраиваем связь
                    using (SqlConnection conn = new SqlConnection(connstr))
                    {
                        conn.Open();
                        //пишем мегазапрос
                        string query = "INSERT INTO [dbo].[Order] ([ID_User], [Data], [Status], [ID_Book]) " +
                                       "VALUES (@id, @date, 'в корзине', @bookId)";
                        //и жесточайшим образом производим его тотальное повсеместное неотвратимое исполнение
                        SqlCommand command = new SqlCommand(query, conn);
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@date", DateTime.Now);
                        command.Parameters.AddWithValue("@bookId", bookId);
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
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
