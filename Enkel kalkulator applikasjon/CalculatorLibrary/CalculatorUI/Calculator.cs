namespace CalculatorUI
{
    public partial class Calculator : Form
    {

        Double value = 0;
        String operation = "";
        bool operandPerformed = false;


        public Calculator()
        {
            InitializeComponent();           
        }

        private void buttonNumberClick(object sender, EventArgs e)
        {
            if ((textBoxResult.Text == "0") || operandPerformed)
                textBoxResult.Clear();

            operandPerformed = false;
            Button numberButton = (Button)sender;
            textBoxResult.Text += numberButton.Text;
        }

        private void buttonClearClick(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            value = 0;
        }

        private void buttonClearEntryClick(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
        }


        private void buttonOperandClick(object sender, EventArgs e)
        {
            Button operandButton = (Button)sender;
            operation = operandButton.Text;
            value = Double.Parse(textBoxResult.Text);
            operandPerformed = true;
            operationDisplay.Text = value + " " + operation;
        }

        private void buttonSummaryClick(object sender, EventArgs e)
        {
            operationDisplay.Text = "";

            switch (operation)
            {
                case "+":
                    textBoxResult.Text = (value + Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "-":
                    textBoxResult.Text = (value - Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "*":
                    textBoxResult.Text = (value * Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "/":
                    textBoxResult.Text = (value / Double.Parse(textBoxResult.Text)).ToString();
                    break;
                default:
                    break;
            }
        }
    }
}