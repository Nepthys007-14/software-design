namespace Task_3_Week_3
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        public Book(string title, string author, double price)
        {
            Title = title;
            Author = author;
            Price = price;
        }

        public virtual string GetInfo()
        {
            return $"Book: {Title} by {Author}, Price: ${Price:F2}";
        }
    }
}
