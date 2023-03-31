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

namespace UniqueListTests;

public class ListsTests
{
    private static IEnumerable<TestCaseData> List()
    {
        yield return new TestCaseData(new UniqueListLibrary.List());
        yield return new TestCaseData(new UniqueListLibrary.UniqueList());
    }

    internal static void FillList(UniqueListLibrary.List list)
    {
        for (var i = 5; i >= 0; i--)
        {
            list.Push(i);
            Assert.That(list.Size, Is.EqualTo(6 - i));
        }
    }

    [TestCaseSource(nameof(List))]
    public void PushToTheHeadTestShouldGiveSameValuesAndRightSize(UniqueListLibrary.List list)
    {
        FillList(list);
        for (var i = 0; i < 5; i++)
        {
            Assert.That(list.Get(i), Is.EqualTo(i));
        }

        Assert.That(list.Size, Is.EqualTo(6));
    }

    [TestCaseSource(nameof(List))]
    public void InsertToHeadTailMiddleShouldRightInsertion(UniqueListLibrary.List list)
    {
        FillList(list);
        list.Insert(10, 2);
        list.Insert(11, 5);
        list.Insert(12, 0);
        list.Insert(44, 9);
        var rightOrder = new int[] { 12, 0, 1, 10, 2, 3, 11, 4, 5, 44};
        for (int i = 0; i < list.Size; ++i)
        {
            Assert.That(list.Get(i), Is.EqualTo(rightOrder[i]));
        }
    }

    [TestCaseSource(nameof(List))]
    public void InsertToInvalidIndexShouldException(UniqueListLibrary.List list)
    {
        FillList(list);
        Assert.Throws<IndexOutOfRangeException> (() => list.Insert(0, -1));
        Assert.Throws<IndexOutOfRangeException>(() => list.Insert(0, 7));
    }

    [TestCaseSource(nameof(List))]
    public void RemoveFromHeadShouldChangeHeadPointer(UniqueListLibrary.List list)
    {
        FillList(list);
        list.Remove(0);
        Assert.Multiple(() =>
        {
            Assert.That(list.Size, Is.EqualTo(5));
            Assert.That(list.Get(0), Is.EqualTo(1));
        });
    }

    [TestCaseSource(nameof(List))]
    public void RemoveFromTailAndMiddleShouldExpectedReaction(UniqueListLibrary.List list)
    {
        FillList(list);
        list.Remove(1);
        Assert.Multiple(() =>
        {
            Assert.That(list.Size, Is.EqualTo(5));
            Assert.That(list.Get(0), Is.EqualTo(0));
            Assert.That(list.Get(1), Is.EqualTo(2));
        });
        list.Remove(4);
        Assert.That(list.Get(3), Is.EqualTo(4));
    }

    [TestCaseSource(nameof(List))]
    public void RemoveWithInvalidIndexShouldException(UniqueListLibrary.List list)
    {
        FillList(list);
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove (-1));
        Assert.Throws<IndexOutOfRangeException>(() => list.Remove(7));
    }

    [TestCaseSource(nameof(List))]
    public void ChangeValuesInHeadTailMiddleShouldExpectedReaction(UniqueListLibrary.List list)
    {
        FillList(list);
        list.ChangeValueByIndex(10, 0);
        list.ChangeValueByIndex(20, 3);
        list.ChangeValueByIndex(30, 5);
        var rightList = new int[] { 10, 1, 2, 20, 4, 30 };
        for (int i = 0; i < list.Size; ++i)
        {
            Assert.That(list.Get(i), Is.EqualTo(rightList[i]));
        }
    }

    [TestCaseSource(nameof(List))]
    public void ChangeWithInvalidIndexShouldException(UniqueListLibrary.List list)
    {
        FillList(list);
        Assert.Throws<IndexOutOfRangeException>(() => list.ChangeValueByIndex(10, -1));
        Assert.Throws<IndexOutOfRangeException>(() => list.ChangeValueByIndex(20, 7));
    }
}