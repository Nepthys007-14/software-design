namespace Task_1_Week_4
{
    public class Ebook : Book
    {
        public double FileSize { get; set; }

        public Ebook(string title, string author, double price, double fileSize)
            : base(title, author, price)
        {
            FileSize = fileSize;
        }

        public override string GetInfo()
        {
            return $"Ebook: {Title} by {Author}, Price: ${Price:F2}, File Size: {FileSize} MB";
        }
    }
}
