using System;
using System.Windows.Forms;

namespace LibralexCalculator
{
    public partial class Calculator : Form
    {
        string strOperator = string.Empty;
        bool operatorActive = false;
        decimal result = 0;

        public Calculator()
        {
            InitializeComponent();
        }

        private void appendValue(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (value.Text == "0")
                value.Clear();

            if(btn.Text.Equals("."))
            {
                if(!(value.Text).EndsWith("."))
                    value.Text += btn.Text;
            }
            else if(btn.Text.Equals("0"))
            {
                if (!(value.Text).Equals("0"))
                    value.Text += btn.Text;
            }
            else
            {
                value.Text = value.Text + btn.Text;
            }
        }

        private void operatorClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            strOperator = btn.Text;
      
            if(operatorActive)
            {
                equation.Text = result + " " + strOperator;
            }
            else
            {
                decimal.TryParse(value.Text, out result);
                value.Text = "0";
                equation.Text = result + " " + strOperator;

                operatorActive = true;
            }
        }

        private void backspace(object sender, EventArgs e)
        {
            if (value.Text.Length < 2)
            {
                value.Text = "0";
            }
            else
            {
                value.Text = value.Text.Remove(value.Text.Length-1);
            }
        }

        private void clear(object sender, EventArgs e)
        {
            value.Text = "0";
        }

        private void changeNotion(object sender, EventArgs e)
        {
            if(Convert.ToDecimal(value.Text) < 0)
            {
                value.Text = Math.Abs(Convert.ToDecimal(value.Text)).ToString();
            }
            else
            {
                value.Text = (Convert.ToDecimal(value.Text) *-1).ToString();
            }
        }

        private void equalsPressed (object sender, EventArgs e)
        {
            equation.Text = string.Empty;
            switch (strOperator)
            {
                case "-":
                    value.Text = (result - (Convert.ToDecimal(value.Text))).ToString();
                    break;
                case "+":
                    value.Text = (result + (Convert.ToDecimal(value.Text))).ToString();
                    break;
                case "*":
                    value.Text = (result * (Convert.ToDecimal(value.Text))).ToString();
                    break;
                case "/":
                    value.Text = (result / (Convert.ToDecimal(value.Text))).ToString();
                    break;
                default:
                    break;
            }

            operatorActive = false;
        }

        private void reset(object sender, EventArgs e)
        {
            value.Text = "0";
            operatorActive = false;
            result = 0;
            strOperator = string.Empty;
            equation.Text = string.Empty;
        }
    }
}
