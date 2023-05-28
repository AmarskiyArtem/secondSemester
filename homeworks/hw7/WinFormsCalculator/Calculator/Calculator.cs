namespace CalculatorLibrary;

using System.ComponentModel;

/// <summary>
/// Calculator that accepts an expression character by character and immediately calculates it
/// </summary>
public class Calculator : INotifyPropertyChanged
{
    private enum States
    {
        NumberIsTyping,
        OperationArePressed,
        SomethingWentWrong,
    }

    private States state = States.NumberIsTyping;

    private string currentResult = "0";

    /// <summary>
    /// String representation of the current value of the expression
    /// </summary>
    public string CurrentResult
    {
        get
        { 
            return currentResult; 
        }
        set
        {
            currentResult = value;
            notifyProperty();
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    private void notifyProperty(string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string intermediateResult = "0";

    private char currentOperation = ' ';

    /// <summary>
    /// Adds digit to expression
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public void AddNumber(char digit)
    {
        if (!char.IsDigit(digit))
        {
            throw new ArgumentException();
        }

        switch (state)
        {
            case States.SomethingWentWrong:
            case States.NumberIsTyping:
                if (currentResult == "0" || currentResult == "Error") 
                {
                    CurrentResult = digit.ToString();
                }
                else
                {
                    CurrentResult += digit;
                }
                state = States.NumberIsTyping;
                break;
            case States.OperationArePressed:
                intermediateResult = currentResult;
                CurrentResult = digit.ToString();
                state = States.NumberIsTyping;
                break;
        }
    }

    /// <summary>
    /// Adds/change pressed operation
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public void AddOperation(char operation)
    {
        if (!"+-*/x÷".Contains(operation))
        {
            throw new ArgumentException();
        }

        switch (state)
        {
            case States.NumberIsTyping:
                if (currentOperation == ' ')
                {
                    intermediateResult = CurrentResult;
                    currentOperation = operation;
                    state = States.OperationArePressed;
                }
                else
                {
                    try
                    {
                        CurrentResult = compute().ToString();
                    }
                    catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                    {
                        Clear();
                        CurrentResult = "Error";
                        state = States.SomethingWentWrong;
                        return;
                    }
                    intermediateResult = CurrentResult;
                    currentOperation = operation;
                    state = States.OperationArePressed;
                }
                break;
            case States.OperationArePressed:
                currentOperation = operation;
                break;
            case States.SomethingWentWrong:
                break;

        }
    }

    private double compute()
    {
        switch (currentOperation)
        {
            case '+':
                return double.Parse(intermediateResult) + double.Parse(CurrentResult);
            case '-':
                return double.Parse(intermediateResult) - double.Parse(CurrentResult);
            case '*':
            case 'x':
                return double.Parse(intermediateResult) * double.Parse(CurrentResult);
            case '/':
            case '÷':
                if (Math.Abs(double.Parse(CurrentResult)) < 0.001)
                {
                    throw new DivideByZeroException();
                }
                return double.Parse(intermediateResult) / double.Parse(CurrentResult);
            default: throw new ArgumentException();
        }
    }

    /// <summary>
    /// Clears expression
    /// </summary>
    public void Clear()
    {
        CurrentResult = "0";
        intermediateResult = "0";
        currentOperation = ' ';
        state = States.NumberIsTyping;
    }

    /// <summary>
    /// Calculate current expression
    /// </summary>
    public void Calculate()
    {
        double result = 0;

        switch (state)
        {
            case States.OperationArePressed:
                try
                {
                    result = compute();
                }
                catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                {
                    Clear();
                    CurrentResult = "Error";
                    state = States.SomethingWentWrong;
                    return;
                }
                CurrentResult = result.ToString();
                break;
            case States.SomethingWentWrong:
            case States.NumberIsTyping:
                if (currentOperation != ' ')
                {
                    try
                    {
                        result = compute();
                    }
                    catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                    {
                        Clear();
                        CurrentResult = "Error";
                        state = States.SomethingWentWrong;
                        return;
                    }

                    CurrentResult = result.ToString();
                    currentOperation = ' ';
                    state = States.NumberIsTyping;
                }
                break;
        }
    }

    /// <summary>
    /// Switches sing of current number
    /// </summary>
    public void SwitchSign()
    {
        if (state != States.SomethingWentWrong && currentResult != "0")
        {
            if (CurrentResult[0] == '-')
            {
                CurrentResult = CurrentResult[1..];
            }
            else
            {
                CurrentResult = "-" + CurrentResult;
            }
        }
    }

}
