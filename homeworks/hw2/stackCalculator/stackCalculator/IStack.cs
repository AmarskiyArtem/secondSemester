namespace StackCalculator;

// Classic stack data structure interface
public interface IStack
{
    // Adds an element to the top of the stack
    public void Push(double value);

    // Removes an element from the top of the stack
    public void Pop();

    // Returns an element from the top of the stack
    public double Top();

    // Check if the stack is empty (contains 0 elements)
    public bool IsEmpty();

}