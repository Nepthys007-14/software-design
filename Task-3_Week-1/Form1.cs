namespace Task_3_Week_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[] SortingList(int[] Nums)
        {
            Array.Sort(Nums);
            return Nums;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] Data = { 5, 4, 1, 2, 3, };
            int[] SortedData = SortingList(Data);

            listBox1.DataSource = SortedData;
        }
    }
}
