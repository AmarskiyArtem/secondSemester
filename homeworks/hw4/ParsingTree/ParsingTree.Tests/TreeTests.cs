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

namespace ParsingTreeTests;

/// <summary>
/// Tests for parsing tree
/// </summary>
public class TreeTests
{
    [Test]
    public void CommonExpressionShouldRightAnswer()
    {
        var tree = new ParsingTree("(* (+ 11 10) 20)");
        Assert.That(tree.CalculateTree(), Is.EqualTo(420).Within(0.001));
    }

    [Test]
    public void DivisionByZeroShouldThrowException()
    {
        var tree = new ParsingTree("+( / 1 0) 3");
        Assert.Throws<DivideByZeroException>(() => tree.CalculateTree());
    }

    [Test]
    public void ExtraOperationsShouldThrowException()
        => Assert.Throws<ArgumentException>(() => new ParsingTree("(- +(* 61 3) 4)"));
    

    [Test]
    public void ExtraOperandsShouldThrowException()
        => Assert.Throws<ArgumentException>(() => new ParsingTree("+ 45 43 34"));
    

    [Test]
    public void EmptyStringShouldThrowException()
        => Assert.Throws<ArgumentException>(() => new ParsingTree(String.Empty));

    [Test]
    public void NullStringShouldThrowException()
        => Assert.Throws<ArgumentNullException>(() => new ParsingTree(null));
    

    [Test]
    public void PrintTreeShouldRightString()
    {
        var tree = new ParsingTree("(* (+ 11 10) 20)");
        var rightAnswer = "* + 11 10 20 ";
        using (var output = new StringWriter())
        {
            Console.SetOut(output);
            tree.PrintTree();
            Assert.That(output.ToString(), Is.EqualTo(rightAnswer));
        }
    }
}