namespace Task_1_Week_4
{
    public class Magazine : Book
    {
        public int IssueNumber { get; set; }

        public Magazine(string title, string author, double price, int issueNumber)
            : base(title, author, price)
        {
            IssueNumber = issueNumber;
        }

        public override string GetInfo()
        {
            return $"Magazine: {Title} by {Author}, Price: ${Price:F2}, Issue #: {IssueNumber}";
        }
    }
}
