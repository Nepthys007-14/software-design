namespace Task_3_Week_3
{
    public class AudioBook : Book
    {
        public double Duration { get; set; }
        public string Narrator { get; set; }

        public AudioBook(string title, string author, double price, double duration, string narrator)
            : base(title, author, price)
        {
            Duration = duration;
            Narrator = narrator;
        }

        public override string GetInfo()
        {
            return $"AudioBook: {Title} by {Author}, Price: ${Price:F2}, Duration: {Duration} hrs, Narrator: {Narrator}";
        }
    }
}
