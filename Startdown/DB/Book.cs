namespace Startdown.DB
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Book()
        {

        }
        public Book(int Id, string Title, string Author)
        {
            this.Id = Id;
            this.Title = Title;
            this.Author = Author;
        }
    }
}
