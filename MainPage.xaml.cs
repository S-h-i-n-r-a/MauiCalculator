using System.Globalization;

namespace LearningMAUI;

#nullable enable
public partial class MainPage : ContentPage
{
	private List<char> _equation = new();
    private bool _valid = true;

	public MainPage()
	{
		InitializeComponent();
	}

    private void EnterChar(char c)
    {
        _equation.Add(c);
        lblEquation.Text = new string(_equation.ToArray());
    }

    private double EvaluateEquation()
    { 
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        List<double> numbers = new();
        List<char> operators = new();
        string? numOrNull = null;

        // Make more easily parseable and check validity
        foreach (char character in _equation)
        {
            switch (character)
            {
                case char c when (c >= '0' && c <= '9'):
                    if (numOrNull == null)
                    {
                        numOrNull = c.ToString();
                    }
                    else
                    {
                        numOrNull += c;
                    }
                    break;

                case '.':
                    if (numOrNull == null || numOrNull.Contains('.'))
                    {
                        _valid = false;
                        return 0.0d;
                    }
                    else
                    {
                        numOrNull += character;
                    }
                    break;

                case char c when (c == '÷' || c == '×' || c == '-' || c == '+' || c == '='):
                    if (numOrNull == null)
                    {
                        _valid = false;
                        return 0.0d;
                    }
                    else
                    {
                        double.TryParse(numOrNull, out double res);
                        numbers.Add(res);
                        operators.Add(c);
                        numOrNull = null;
                    }
                    break;
            }
        }

        // Perform multiplication and division
        for (int i = 0; i < operators.Count; ++i)
        {
            char op = operators[i];

            if (op == '÷')
            {
                numbers[i] = numbers[i] / numbers[i + 1];
                numbers.RemoveAt(i + 1);
                operators.RemoveAt(i);
            }

            else if (op == '×')
            {
                numbers[i] = numbers[i] * numbers[i + 1];
                numbers.RemoveAt(i + 1);
                operators.RemoveAt(i);
            }
        }

        // Perform addition and subtraction
        for (int i = 0; i < operators.Count; ++i)
        {
            char op = operators[i];

            if (op == '-')
            {
                numbers[i] = numbers[i] - numbers[i + 1];
                numbers.RemoveAt(i + 1);
                operators.RemoveAt(i);
            }

            else if (op == '+')
            {
                numbers[i] = numbers[i] + numbers[i + 1];
                numbers.RemoveAt(i + 1);
                operators.RemoveAt(i);
            }
        }

        return numbers[0];
    }

    #region Numbers
    private void BtnNumZero_Clicked(object sender, EventArgs e) { EnterChar('0'); }
    private void BtnNumOne_Clicked(object sender, EventArgs e) { EnterChar('1'); }
    private void BtnNumTwo_Clicked(object sender, EventArgs e) { EnterChar('2'); }
    private void BtnNumThree_Clicked(object sender, EventArgs e) { EnterChar('3'); }
    private void BtnNumFour_Clicked(object sender, EventArgs e) { EnterChar('4'); }
    private void BtnNumFive_Clicked(object sender, EventArgs e) { EnterChar('5'); }
    private void BtnNumSix_Clicked(object sender, EventArgs e) { EnterChar('6'); }
    private void BtnNumSeven_Clicked(object sender, EventArgs e) { EnterChar('7'); }
    private void BtnNumEight_Clicked(object sender, EventArgs e) { EnterChar('8'); }
    private void BtnNumNine_Clicked(object sender, EventArgs e) { EnterChar('9'); }
    private void BtnDot_Clicked(object sender, EventArgs e) { EnterChar('.'); }
    #endregion

    #region Operator keys
    private void BtnDivide_Clicked(object sender, EventArgs e) { EnterChar('÷'); }
    private void BtnMultiply_Clicked(object sender, EventArgs e) { EnterChar('×'); }
    private void BtnSubtract_Clicked(object sender, EventArgs e) { EnterChar('-'); }
    private void BtnAdd_Clicked(object sender, EventArgs e) { EnterChar('+'); }

    
    private void BtnBackspace_Clicked(object sender, EventArgs e) 
    {
        if (!_valid)
        {
            lblEquation.Text = new string(_equation.ToArray());
            _valid = true;
            return;
        }
        if (_equation.Count == 0) { return; }

        _equation.RemoveAt(_equation.Count -1);
        lblEquation.Text = new string(_equation.ToArray());
    }
    private void BtnClear_Clicked(object sender, EventArgs e) 
    {
        _equation.Clear();
        lblEquation.Text = "";
    }
    private void BtnEquals_Clicked(object sender, EventArgs e)
    {
        EnterChar('=');
        string result = EvaluateEquation().ToString();

        if (!_valid)
        {
            lblEquation.Text = "Invalid, press ⌫ to edit.";
            SemanticScreenReader.Announce("Invalid equation, press backspace to edit.");
            return;
        }

        lblEquation.Text = result;
        _equation = result.ToCharArray().ToList();
    }
    #endregion
}

