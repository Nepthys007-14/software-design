namespace Task_4_Week_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class NumberSorter
        {
            public int[]? Numbers { get; set; }

            public void SortNums(int[] nums)
            {
                Numbers = nums;
            }

            public void Sort()
            {
                if (Numbers != null)
                {
                    Array.Sort(Numbers);
                }
                else
                {
                    MessageBox.Show("Numbers array is not initialized.");
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NumberSorter sorter = new NumberSorter();

            int[] nums = { 5, 2, 9, 1, 5, 6 };

            sorter.SortNums(nums);

            sorter.Sort();

            listBox1.DataSource = null; 
            listBox1.DataSource = sorter.Numbers;
        }
    }
}
