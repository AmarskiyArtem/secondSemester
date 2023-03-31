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
using System.Collections.Generic;

// Stack implementation using a list
public class StackOnList : IStack
{
    public StackOnList() 
        => this.data = new ();

    private readonly List<double> data;

    public void Push(double value)
        => this.data.Insert(0, value);

    public void Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        this.data.Remove(this.data[0]);
    }

    public double Top()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return this.data[0];
    }

    public bool IsEmpty()
        => this.data.Count == 0;

    // Tests
    public static bool Tests()
    {
        var stack = new StackOnList();
        try
        {
            stack.Pop();
            return false;
        }
        catch (InvalidOperationException) { }
        stack.Push(5);
        stack.Push(8);
        stack.Push(4);
        if (stack.Top() != 4) 
        {
            return false;
        }
        stack.Pop();
        stack.Pop();
        if (stack.Top() != 5) 
        {
            return false;
        }
        stack.Pop();
        try
        {
            stack.Top();
            return false;
        }
        catch (InvalidOperationException) { }
        return true;
    }
}