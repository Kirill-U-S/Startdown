using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Startdown.DB;
using System.Data.SqlClient;

namespace Startdown.Controllers
{
    public class CatalogController : Controller
    {
        // GET: CatalogController]
        List<Book> books = new List<Book>();
        public ActionResult Index()
        {
            string connstr = "Data Source=BEST-KOMP;Initial Catalog=SD_DB;Integrated Security=True";
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
