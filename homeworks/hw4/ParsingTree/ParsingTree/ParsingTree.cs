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

namespace ParsingTreeLibrary;

/// <summary>
/// The parsing tree of a mathematical expression
/// </summary>
public class ParsingTree
{
    /// <param name="expression"> math expression</param>
    /// <exception cref="ArgumentException">if string is empty or incorrect math expression</exception>
    /// <exception cref="ArgumentNullException"></exception>
    public ParsingTree(string? expression)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(expression);
        FillTree(expression);
        if (root is null) 
        {
            throw new InvalidOperationException();
        }
    }

    private INode root;

    private void FillTree(string expression)
    {
        var parts = expression.Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        var index = -1;
        INode AddNode()
        {
            index++;
            if (index >= parts.Length)
            {
                throw new ArgumentException("Incorrect math expression.");
            }
            if (char.IsDigit(parts[index][0]))
            {
                return new Operand(int.Parse(parts[index]));
            }

            Operation? newNode = parts[index] switch
            {
                "*" => new Multiplication(),
                "/" => new Division(),
                "+" => new Addition(),
                "-" => new Subtraction(),
                _ => throw new ArgumentException("Incorrect math expression."),
            };
            newNode.LeftChild = AddNode();
            newNode.RightChild = AddNode();
            return newNode;
        }
        root = AddNode();
        if (index != parts.Length - 1)
        {
            throw new ArgumentException("Incorrect math expression.");
        }
    }

    /// <summary>
    /// Сalculates the value of an expression in the parse tree
    /// </summary>
    public double CalculateTree()
        => root.Calculate();

    /// <summary>
    /// Print tree to the console
    /// </summary>
    public void PrintTree()
        => root.Print();
}
