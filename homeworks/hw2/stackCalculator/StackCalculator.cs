﻿namespace StackCalculator;

using System;

internal static class StackCalculator
{
    static bool IsCorrectExpression(string expression)
    {
        var correctSymbols = " 0123456789+-*/";
        return expression != null && expression.All(x => correctSymbols.Contains(x));
    }

    static bool IsZero(double value) => Math.Abs(value) < 0.0001;

    public static double CalculatePostfixExpression(string expression, IStack stack)
    {
        if (!IsCorrectExpression(expression))
        {
            throw new ArgumentException("Incorrect math expression.");
        }

        var operations = "+-*/";
        foreach (var element in expression.Split())
        {
            if (operations.Contains(element))
            {
                var secondValue = stack.Top();
                stack.Pop();
                var firstValue = stack.Top();
                stack.Pop();
                switch (element)
                {
                    case "+":
                        stack.Push(secondValue + firstValue);
                        break;
                    case "-":
                        stack.Push(firstValue - secondValue);
                        break;
                    case "*":
                        stack.Push(firstValue * secondValue);
                        break;
                    case "/":
                        if (IsZero(secondValue))
                        {
                            throw new DivideByZeroException("Attempted to divide by zero.");
                        }
                        stack.Push(firstValue / secondValue);
                        break;
                }
            }
            else
            {
                stack.Push(int.Parse(element));
            }

        }
        var result = stack.Top();
        stack.Pop();
        if (!stack.IsEmpty())
        {
            throw new ArgumentException("Incorrect math expression.");
        }
        return result;
    }

    public static bool Tests()
    {
        return true;
    }
}

