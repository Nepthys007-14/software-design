namespace Task_3_Week_4
{
    public class Textbook : Book
    {
        public string Subject { get; set; }

        public Textbook(string title, string author, double price, string subject)
            : base(title, author, price)
        {
            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentException("Subject cannot be empty.");

            Subject = subject;
        }

        public override string GetInfo()
        {
            return $"Textbook: {Title} by {Author}, Price: ${Price:F2}, Subject: {Subject}";
        }
    }
}
