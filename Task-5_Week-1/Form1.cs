using System.ComponentModel;

namespace Task_5_Week_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class NumbersSort
        {
            public int[] Number { get; set; }

            public NumbersSort(int[] number)
            {
                Number = number;
            }
        }

        public void BoubleSort(int[] Numbers)
        {
            if(!Numbers.Any() || Numbers.Length == 0)
            {
                MessageBox.Show("Array is empty");
                return;
            }

            int n = Numbers.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Numbers[j] > Numbers[j + 1])
                    {
                        var temp = Numbers[j];
                        Numbers[j] = Numbers[j + 1];
                        Numbers[j + 1] = temp;
                    }
                }
            }
        }

        public void ShowSortedNumbers()
        {
            int[] Data = { 1, 5, 7, 3, 2, 1, 3, 4, 67, 7, 1, 1, 1, 1, };

            NumbersSort sorter = new NumbersSort(Data);

            BoubleSort(sorter.Number);

            listBox1.DataSource = null;
            listBox1.DataSource = sorter.Number;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowSortedNumbers();
        }
    }
}
