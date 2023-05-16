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

    private char operation = ' ';

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
}
