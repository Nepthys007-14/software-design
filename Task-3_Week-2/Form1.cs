namespace Task_3_Week_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ==========================================
        // 1. Recursive Fibonacci Sequence
        // ==========================================
        // The Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8, 13, 21, ...
        // F(0) = 0, F(1) = 1
        // F(n) = F(n-1) + F(n-2)
        private long Fibonacci(int n)
        {
            // Base Cases
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;

            // Recursive Case: F(n) = F(n-1) + F(n-2)
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private void btnFibonacci_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFibInput.Text, out int n))
            {
                if (n < 0)
                {
                    lblFibResult.Text = "Error: Please enter a non-negative integer.";
                }
                else if (n > 40)
                {
                    lblFibResult.Text = "Error: Number too large (max 40 for performance).";
                }
                else
                {
                    long result = Fibonacci(n);
                    lblFibResult.Text = $"F({n}) = {result}";
                }
            }
            else
            {
                lblFibResult.Text = "Error: Please enter a valid integer.";
            }
        }

        // ==========================================
        // 2. Recursive Power Calculation
        // ==========================================
        // x^n = x * x^(n-1)
        // Base Case: x^0 = 1
        private double Power(double x, int n)
        {
            // Base Case: any number raised to the power of 0 is 1
            if (n == 0)
                return 1;

            // Handle negative exponents: x^(-n) = 1 / x^n
            if (n < 0)
                return 1.0 / Power(x, -n);

            // Recursive Case: x^n = x * x^(n-1)
            return x * Power(x, n - 1);
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtBase.Text, out double baseValue) &&
                int.TryParse(txtExponent.Text, out int exponent))
            {
                double result = Power(baseValue, exponent);
                lblPowerResult.Text = $"{baseValue}^{exponent} = {result}";
            }
            else
            {
                lblPowerResult.Text = "Error: Please enter valid numbers.";
            }
        }
    }
}
