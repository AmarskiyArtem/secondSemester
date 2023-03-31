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

namespace StackCalculatorTests;

public class PostfixCalculatorTests
{
    private StackOnLinkedList stack = new();

    [SetUp]
    public void Setup()
    {
        stack = new StackOnLinkedList();
    }

    [Test]
    public void StandartExpessionShouldGiveRightAnswer()
    {
        var result = PostfixCalculator.CalculatePostfixExpression("5 7 + 3 * 4 /", stack);
        Assert.That(result, Is.EqualTo(9));
    }

    [Test]
    public void OnlyOneNumberShouldReturnTheSame()
    {
        var result = PostfixCalculator.CalculatePostfixExpression("4", stack);
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void DivideByZeroShouldException()
    {
        Assert.Throws<DivideByZeroException>(()
            => PostfixCalculator.CalculatePostfixExpression("1 5 3 / 5 3 / - /", stack));
    }

    [Test]
    public void ExtraNumbersShouldException()
    {
        var ex = Assert.Throws<ArgumentException>(()
            => PostfixCalculator.CalculatePostfixExpression("1 2 3 +", stack));
        Assert.That(ex.Message, Is.EqualTo("Incorrect math expression."));
    }

    [Test]
    public void ExtraOperandsShouldException()
    {
        var ex = Assert.Throws<ArgumentException>(()
            => PostfixCalculator.CalculatePostfixExpression("1 3 + -", stack));
        Assert.That(ex.Message, Is.EqualTo("Incorrect math expression."));
    }

    [Test]
    public void UnresolvedCharactersShouldException()
    {
        var ex = Assert.Throws<ArgumentException>(()
            => PostfixCalculator.CalculatePostfixExpression("1 3 + (5 5) *", stack));
        Assert.That(ex.Message, Is.EqualTo("Incorrect math expression."));
    }

}