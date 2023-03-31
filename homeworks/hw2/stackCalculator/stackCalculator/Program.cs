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

using StackCalculator;


if (!(PostfixCalculator.Tests() && StackOnList.Tests() && StackOnLinkedList.Tests()))
{
    Console.WriteLine("Tests failed");
    return;
}

Console.WriteLine("Enter math expression in postfix form");
var expression = Console.ReadLine();

try
{
    var listStack = new StackOnList();
    var result = PostfixCalculator.CalculatePostfixExpression(expression, listStack);
    Console.WriteLine("Calculation result using stack on list: " + result);

    var linkedListStack = new StackOnLinkedList();
    result = PostfixCalculator.CalculatePostfixExpression(expression, linkedListStack);
    Console.WriteLine("Calculation result using stack on linked list: " + result);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Error! " + ex.Message);
}
catch (ArgumentException ex)
{
    Console.WriteLine("Error! " + ex.Message);
}



