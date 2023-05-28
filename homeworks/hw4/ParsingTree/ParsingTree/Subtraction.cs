﻿/*
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
/// Implementation opetation for "-" case
/// </summary>
internal class Subtraction : Operation
{
    /// <inheritdoc/>
    public override void Print()
    {
        Console.Write("- ");
        base.Print();
    }

    /// <inheritdoc/>
    public override double Calculate()
    {
        if (LeftChild is null || RightChild is null)
        {
            throw new InvalidOperationException();
        }
        return LeftChild.Calculate() - RightChild.Calculate(); 
    }
}
