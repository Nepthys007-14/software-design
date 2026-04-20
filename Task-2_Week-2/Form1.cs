namespace Task_2_Week_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Recursive Function for Summing an Array
        private int SumArray(int[] arr, int index)
        {
            // Base Case: if index reaches the end of the array
            if (index >= arr.Length)
                return 0;

            // Recursive Case: current element + sum of remaining elements
            return arr[index] + SumArray(arr, index + 1);
        }

        private void btnCalculateSum_Click(object sender, EventArgs e)
        {
            try
            {
                // Split the input by commas and parse each value
                string[] parts = txtArrayInput.Text.Split(',');
                int[] numbers = new int[parts.Length];

                for (int i = 0; i < parts.Length; i++)
                {
                    numbers[i] = int.Parse(parts[i].Trim());
                }

                // Calculate the sum using recursion
                int sum = SumArray(numbers, 0);

                lblSumResult.Text = $"Sum = {sum}";
            }
            catch (FormatException)
            {
                lblSumResult.Text = "Error: Please enter valid comma-separated integers.";
            }
            catch (Exception ex)
            {
                lblSumResult.Text = $"Error: {ex.Message}";
            }
        }
    }
}
