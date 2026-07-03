using System.Windows.Forms.VisualStyles;

namespace Lesson_12
{
    public partial class FormMain : Form
    {
        private Fraction? currentFraction = null;
        private Fraction? previousFraction = null;

        public FormMain()
        {
            InitializeComponent();
            Application.ThreadException += Application_ThreadException;
        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"An error occurred: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            textBoxCalc.Text = textBoxCalc.Text + "1";
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            textBoxCalc.Text = textBoxCalc.Text + "2";
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            textBoxCalc.Text = textBoxCalc.Text + "3";
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            textBoxCalc.Text = textBoxCalc.Text + "4";
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            textBoxCalc.Text = textBoxCalc.Text + "5";
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            textBoxCalc.Text = textBoxCalc.Text + "6";
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            textBoxCalc.Text = textBoxCalc.Text + "7";
        }
        private void buttonEight_Click(object sender, EventArgs e)
        {
            textBoxCalc.Text = textBoxCalc.Text + "8";
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            textBoxCalc.Text = textBoxCalc.Text + "9";
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            textBoxCalc.Text = textBoxCalc.Text + "0";
        }

        private void buttonSlash_Click(object sender, EventArgs e)
        {
            if(!textBoxCalc.Text.Contains("/"))
                textBoxCalc.Text = textBoxCalc.Text + "/";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxCalc.Text = "";
        }

        private void buttonClearEverything_Click(object sender, EventArgs e)
        {
            currentFraction = null;
            previousFraction = null;
            textBoxCalc.Text = "";
            textBoxPrev.Text = "";
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (textBoxCalc.Text.Length > 0)
            {
                textBoxCalc.Text = textBoxCalc.Text.Substring(0, textBoxCalc.Text.Length - 1);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxCalc.Text.Length > 0)
            {
                currentFraction = Fraction.Parse(textBoxCalc.Text);

                if (previousFraction != null)
                {
                    previousFraction = currentFraction + previousFraction;
                    textBoxPrev.Text = previousFraction.ToString() + " +";
                    textBoxCalc.Text = "";
                }
                else
                {
                    previousFraction = Fraction.Parse(textBoxCalc.Text);
                    textBoxPrev.Text = previousFraction.ToString() + " +";
                    textBoxCalc.Text = "";
                }
            }
            else
            {
                if (textBoxPrev.Text.Length > 0)
                    textBoxPrev.Text = textBoxPrev.Text.Substring(0, textBoxPrev.Text.Length - 1) + "+";
            }
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            if (textBoxCalc.Text.Length > 0)
            {
                currentFraction = Fraction.Parse(textBoxCalc.Text);

                if (previousFraction != null)
                {
                    previousFraction = currentFraction - previousFraction;
                    textBoxPrev.Text = previousFraction.ToString() + " -";
                    textBoxCalc.Text = "";
                }
                else
                {
                    previousFraction = Fraction.Parse(textBoxCalc.Text);
                    textBoxPrev.Text = previousFraction.ToString() + " -";
                    textBoxCalc.Text = "";
                }
            }
            else
            {
                if (textBoxPrev.Text.Length > 0)
                    textBoxPrev.Text = textBoxPrev.Text.Substring(0, textBoxPrev.Text.Length - 1) + "-";
            }
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (textBoxCalc.Text.Length > 0)
            {
                currentFraction = Fraction.Parse(textBoxCalc.Text);

                if (previousFraction != null)
                {
                    previousFraction = currentFraction * previousFraction;
                    textBoxPrev.Text = previousFraction.ToString() + " x";
                    textBoxCalc.Text = "";
                }
                else
                {
                    previousFraction = Fraction.Parse(textBoxCalc.Text);
                    textBoxPrev.Text = previousFraction.ToString() + " x";
                    textBoxCalc.Text = "";
                }
            }
            else
            {
                if (textBoxPrev.Text.Length > 0)
                    textBoxPrev.Text = textBoxPrev.Text.Substring(0, textBoxPrev.Text.Length - 1) + "x";
            }
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (textBoxCalc.Text.Length > 0)
            {
                currentFraction = Fraction.Parse(textBoxCalc.Text);

                if (previousFraction != null)
                {
                    if (currentFraction.getNumerator() == 0)
                        throw new ArgumentException("Cannot divide by zero.");
                    previousFraction = previousFraction / currentFraction;
                    textBoxPrev.Text = previousFraction.ToString() + " ÷";
                    textBoxCalc.Text = "";
                }
                else
                {
                    previousFraction = Fraction.Parse(textBoxCalc.Text);
                    textBoxPrev.Text = previousFraction.ToString() + " ÷";
                    textBoxCalc.Text = "";
                }
            }
            else
            {
                if (textBoxPrev.Text.Length > 0)
                    textBoxPrev.Text = textBoxPrev.Text.Substring(0, textBoxPrev.Text.Length - 1) + "÷";
            }
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (textBoxCalc.Text.Length > 0)
            {
                currentFraction = Fraction.Parse(textBoxCalc.Text);

                if (previousFraction != null)
                {
                    char getOperator = textBoxPrev.Text.Length > 0 ? textBoxPrev.Text[textBoxPrev.Text.Length - 1] : '\0';
                    int indexSlash;

                    switch (getOperator)
                    {
                        case '+':
                            currentFraction = previousFraction + currentFraction;
                            previousFraction = null;
                            textBoxPrev.Text = "";
                            indexSlash = currentFraction.ToString().IndexOf('/');
                            if (currentFraction.ToString().Substring(indexSlash + 1) == "1")
                            {
                                textBoxCalc.Text = currentFraction.ToString().Substring(0, indexSlash);
                            }
                            else
                            {
                                textBoxCalc.Text = currentFraction.ToString();
                            }
                            break;

                        case '-':
                            currentFraction = previousFraction - currentFraction;
                            previousFraction = null;
                            textBoxPrev.Text = "";
                            indexSlash = currentFraction.ToString().IndexOf('/');
                            if (currentFraction.ToString().Substring(indexSlash + 1) == "1")
                            {
                                textBoxCalc.Text = currentFraction.ToString().Substring(0, indexSlash);
                            }
                            else
                            {
                                textBoxCalc.Text = currentFraction.ToString();
                            }
                            break;

                        case 'x':
                            currentFraction = previousFraction * currentFraction;
                            previousFraction = null;
                            textBoxPrev.Text = "";
                            indexSlash = currentFraction.ToString().IndexOf('/');
                            if (currentFraction.ToString().Substring(indexSlash + 1) == "1")
                            {
                                textBoxCalc.Text = currentFraction.ToString().Substring(0, indexSlash);
                            }
                            else
                            {
                                textBoxCalc.Text = currentFraction.ToString();
                            }
                            break;

                        case '÷':
                            if (currentFraction.getNumerator() == 0)
                                throw new ArgumentException("Cannot divide by zero.");
                            currentFraction = previousFraction / currentFraction;
                            previousFraction = null;
                            textBoxPrev.Text = "";
                            indexSlash = currentFraction.ToString().IndexOf('/');
                            if (currentFraction.ToString().Substring(indexSlash + 1) == "1")
                            {
                                textBoxCalc.Text = currentFraction.ToString().Substring(0, indexSlash);
                            }
                            else
                            {
                                textBoxCalc.Text = currentFraction.ToString();
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            else
            {
                if (previousFraction != null)
                    textBoxCalc.Text = previousFraction.ToString();
                previousFraction = null;
                textBoxPrev.Text = "";
            }
        }

        private void textBoxCalc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '/' && e.KeyChar != '\b' && e.KeyChar != '\r' && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '+')
            {
                if (textBoxCalc.Text.Length > 0)
                    buttonAdd_Click(sender, e);
                e.Handled = true;
            }

            if (e.KeyChar == '-')
            {
                if (textBoxCalc.Text.Length > 0)
                    buttonSubtract_Click(sender, e);
                e.Handled = true;
            }

            if (e.KeyChar == '*')
            {
                if (textBoxCalc.Text.Length > 0)
                    buttonMultiply_Click(sender, e);
                e.Handled = true;
            }

            if (e.KeyChar == '/' && textBoxCalc.Text.Contains("/"))
            {
                if (textBoxCalc.Text != "/" && textBoxCalc.Text.Length > 0)
                    buttonDivide_Click(sender, e);
                e.Handled = true;
            }

            if (e.KeyChar == '\r')
            {
                if (textBoxCalc.Text.Length > 0)
                    buttonEqual_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
