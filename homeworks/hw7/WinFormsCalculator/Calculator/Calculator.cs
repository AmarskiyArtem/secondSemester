namespace CalculatorLibrary;

using System.ComponentModel;

public class Calculator : INotifyPropertyChanged
{
    private enum states
    {
        NumberIsTyping,
        OperationArePressed,
        SomethingWentWrong,
    }

    private states state = states.NumberIsTyping;

    private string currentResult = "0";

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

    public void AddNumber(char digit)
    {
        if (!char.IsDigit(digit))
        {
            throw new ArgumentException();
        }

        switch (state)
        {
            case states.SomethingWentWrong:
            case states.NumberIsTyping:
                if (currentResult == "0" || currentResult == "Error") 
                {
                    currentResult = digit.ToString();
                }
                else
                {
                    currentResult += digit;
                }
                state = states.NumberIsTyping;
                break;
            case states.OperationArePressed:
                intermediateResult = currentResult;
                currentResult = digit.ToString();
                state = states.NumberIsTyping;
                break;
        }
    }

    public void AddOperation(char operation)
    {
        if (!"+-*/".Contains(operation))
        {
            throw new ArgumentException();
        }

        switch (state)
        {
            case states.NumberIsTyping:
                if (operation == ' ')
                {
                    intermediateResult = currentResult;
                    currentOperation = operation;
                    state = states.OperationArePressed;
                }
                else
                {
                    try
                    {
                        currentResult = compute().ToString();
                    }
                    catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                    {
                        Clear();
                        currentResult = "Error";
                        state = states.SomethingWentWrong;
                        return;
                    }
                    intermediateResult = currentResult;
                    currentOperation = operation;
                    state = states.OperationArePressed;
                }
                break;
            case states.OperationArePressed:
                currentOperation = operation;
                break;
            case states.SomethingWentWrong:
                break;

        }
    }

    private double compute()
    {
        switch (currentOperation)
        {
            case '+':
                return double.Parse(intermediateResult) + double.Parse(currentResult);
            case '-':
                return double.Parse(intermediateResult) - double.Parse(currentResult);
            case '*':
                return double.Parse(intermediateResult) - double.Parse(currentResult);
            case '/':
                if (Math.Abs(double.Parse(currentResult)) < 0.001)
                {
                    throw new DivideByZeroException();
                }
                return double.Parse(intermediateResult) / double.Parse(currentResult);
            default: throw new ArgumentException();
        }
    }

    public void Clear()
    {
        currentResult = "0";
        intermediateResult = "0";
        currentOperation = ' ';
        state = states.NumberIsTyping;
    }

    public void Calculate()
    {
        double result = 0;

        switch (state)
        {
            case states.OperationArePressed:
                try
                {
                    result = compute();
                }
                catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                {
                    Clear();
                    currentResult = "Error";
                    state = states.SomethingWentWrong;
                    return;
                }
                currentResult = result.ToString();
                break;
            case states.SomethingWentWrong:
            case states.NumberIsTyping:
                if (currentOperation != ' ')
                {
                    try
                    {
                        result = compute();
                    }
                    catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                    {
                        Clear();
                        currentResult = "Error";
                        state = states.SomethingWentWrong;
                        return;
                    }

                    currentResult = result.ToString();
                    currentOperation = ' ';
                    state = states.NumberIsTyping;
                }
                break;
        }
    }

    public void SwitchSign()
    {
        if (state != states.SomethingWentWrong && currentResult != "0")
        {
            if (currentResult[0] == '-')
            {
                currentResult = currentResult[1..];
            }
            else
            {
                currentResult = "-" + currentResult;
            }
        }
    }

}
