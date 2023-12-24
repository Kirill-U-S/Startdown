namespace Startdown.DB
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Data { get; set; }
        public string Status { get; set; }
        /// <summary>
        /// данный конструктор для создания листов и т.д. т.е. технический
        /// </summary>
        public Book()
        {

        }
        /// <summary>
        /// данный конструктор общего назначения
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Title"></param>
        /// <param name="Author"></param>
        public Book(int Id, string Title, string Author)
        {
            this.Id = Id;
            this.Title = Title;
            this.Author = Author;
        }
        /// <summary>
        /// данный конструктор локализован под список на странице Basket
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Data"></param>
        /// <param name="Status"></param>
        /// <param name="forbasket">параметр можно оставить пустым</param>
        public Book(int Id, string Data, string Status, int forbasket = 0)
        {
            this.Id = Id;
            this.Data = Data;
            this.Status = Status;
        }
        /// <summary>
        /// Этот супермегакрутой конструктор прям капец очень широкого назначения он нужен нам для баскета
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="data"></param>
        /// <param name="status"></param>
        public Book(int id, string title, string author, string data, string status)
        {
            Id = id;
            Title = title;
            Author = author;
            Data = data;
            Status = status;
        }
    }
}
