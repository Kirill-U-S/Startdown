using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Startdown.DB;
using System.Data;
using System.Data.SqlClient;

namespace Startdown.Controllers
{
    public class BasketController : Controller
    {
        List<Book> booksbasket = new List<Book>();
        void PrintBooks()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                TempData["Message"] = $"Авторизуйтесь или зарегистрируйтесь";
                RedirectToAction("Index", "Home");
            }
            else
            {
                //считали id пользователя
                int id = 0;
                id = int.Parse(HttpContext.Session.GetString("id"));
                //написали запрос на вытягивание пользовательской корзины
                string query = "select [dbo].[Order].[ID_Book], [dbo].[Order].[Status], [dbo].[Order].[Data] from [dbo].[Order]" +
                    $"where [dbo].[Order].[ID_User] = '{id}'";
                //открываем соединение
                string connstr = "Data Source=DESKTOP-UIR8C5V;Initial Catalog=StartDown_DB;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();
                    //выполняем запрос
                    SqlCommand cmd = new SqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();
                    //достаем информацию
                    List<Book> books = new List<Book>();
                    while (reader.Read())
                    {
                        int idbook = reader.GetInt32(0);
                        string status = reader.GetString(1);
                        string data = reader.GetDateTime(2).ToString();

                        Book book = new Book(idbook, status, data, 0);
                        books = books.Append(book).ToList();
                    }
                    reader.Close();
                    cmd.Dispose();
                    //Второй запрос на вытягивание названия книги и его автора
                    booksbasket = new List<Book>();
                    foreach (var book in books)
                    {
                        string query1 = "select [dbo].[Books].[Title], [dbo].[Books].[Author] from [dbo].[Books]" +
                            $"where [dbo].[Books].[ID] = '{book.Id}'";
                        SqlCommand command = new SqlCommand(query1, conn);
                        var reader1 = command.ExecuteReader();
                        while (reader1.Read())
                        {
                            Book bk = new Book(book.Id, reader1.GetString(0), reader1.GetString(1), book.Data, book.Status);
                            booksbasket = booksbasket.Append(bk).ToList();
                        }
                        command.Dispose();
                        reader1.Close();
                    }

                    conn.Close();
                }
            }
        }
        // GET: BasketController
        public ActionResult Index()
        {
            PrintBooks();
            return View(booksbasket);
        }

        // GET: BasketController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BasketController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BasketController/Create
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

        // GET: BasketController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BasketController/Edit/5
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

        // GET: BasketController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BasketController/Delete/5
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
