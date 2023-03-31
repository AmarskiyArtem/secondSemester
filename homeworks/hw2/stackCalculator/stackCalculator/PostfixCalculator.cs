/*
 * This file is part of project "Second Semester".
 * Copyright (c) [2023] [Artem Amarskiy].
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     https://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace StackCalculator;

using System;

// A static class capable of computing math expressions in postfix notation
public static class PostfixCalculator
{
    static bool IsCorrectExpression(string expression)
    {
        var correctSymbols = " 0123456789+-*/";
        return expression != null && expression.All(x => correctSymbols.Contains(x));
    }

    static bool IsZero(double value) => Math.Abs(value) < 0.0001;

    // Accepts the math expression in postfix notation and a stack, returns result of calculation
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
                double firstValue;
                double secondValue;
                try
                {
                    secondValue = stack.Top();
                    stack.Pop();
                    firstValue = stack.Top();
                    stack.Pop();
                }
                catch (InvalidOperationException)
                {
                    throw new ArgumentException("Incorrect math expression.");
                }
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
                            throw new DivideByZeroException();
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

    // Tests
    public static bool Tests()
    {
        var stack = new StackOnLinkedList();
        if (CalculatePostfixExpression("5 7 + 3 * 4 /", stack) != 9)
        {
            return false;
        }
        try
        {
            CalculatePostfixExpression("4 6 + 7 3 - 0 /", stack); //divide by zero test
            return false;
        }
        catch (DivideByZeroException) { }
        try
        {
            CalculatePostfixExpression("(5 7 +) 3 * 4 /", stack); //Incorrect symbols test
            return false;
        }
        catch (ArgumentException) { }
        try
        {
            CalculatePostfixExpression("5 7 8 -", stack);
            return false;
        }
        catch (ArgumentException) { }
        try
        {
            CalculatePostfixExpression("5 7 8 - + *", stack);
            return false;

        }
        catch (ArgumentException) { }
        return true;
    }
}