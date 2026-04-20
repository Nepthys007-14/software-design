namespace Task_1_Week_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private long Factorial(int n)
        {
            if (n == 0)
                return 1;

            return n * Factorial(n - 1);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtInput.Text, out int number))
            {
                if (number < 0)
                {
                    lblResult.Text = "Error: Please enter a non-negative integer.";
                }
                else if (number > 20)
                {
                    lblResult.Text = "Error: Number too large (max 20 to avoid overflow).";
                }
                else
                {
                    long result = Factorial(number);
                    lblResult.Text = $"{number}! = {result}";
                }
            }
            else
            {
                lblResult.Text = "Error: Please enter a valid integer.";
            }
        }
    }
}
