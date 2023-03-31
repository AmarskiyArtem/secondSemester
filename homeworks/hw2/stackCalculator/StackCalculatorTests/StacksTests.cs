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

namespace StackCalculatorTests;

public class StacksTests
{
    private static IEnumerable<TestCaseData> Stack()
    {
        yield return new TestCaseData(new StackOnLinkedList());
        yield return new TestCaseData(new StackOnList());
    }

    [TestCaseSource(nameof(Stack))]
    public void PushAndTopShouldSameValue(IStack stack)
    {
        stack.Push(1);
        Assert.That(stack.Top, Is.EqualTo(1));
    }

    [TestCaseSource(nameof(Stack))]
    public void TwoPushAndTwoTopShouldSameValue(IStack stack)
    {
        stack.Push(2);
        stack.Push(3);
        Assert.That(stack.Top, Is.EqualTo(3));
        stack.Pop();
        Assert.That(stack.Top, Is.EqualTo(2));
    }

    [TestCaseSource(nameof(Stack))]
    public void TopFromEmptyStackShouldException(IStack stack)
    {
        Assert.Throws<InvalidOperationException>(() => stack.Top());
    }

    [TestCaseSource(nameof(Stack))]
    public void PopFromEmptyStackShouldException(IStack stack)
    {
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }
}
