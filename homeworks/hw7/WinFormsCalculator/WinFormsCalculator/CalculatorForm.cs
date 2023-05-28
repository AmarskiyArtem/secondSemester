using CalculatorLibrary;

namespace WinFormsCalculator;

public partial class CalculatorForm : Form
{
    private Calculator calculator = new();

    public CalculatorForm()
    {
        InitializeComponent();
        result.DataBindings.Add("Text", calculator, "CurrentResult", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void NumberClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        calculator.AddNumber(button.Text.First());
    }

    private void OperationClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        calculator.AddOperation(button.Text.First());
    }

    private void EqualClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        calculator.Calculate();
    }

    private void ClearClick(object sender, EventArgs e)
    {
        calculator.Clear();
    }

    private void SignClick(object sender, EventArgs e)
    {
        calculator.SwitchSign();
    }
}
