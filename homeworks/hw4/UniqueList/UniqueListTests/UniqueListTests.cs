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

public class UniqueListTests
{
    private UniqueList uniqueList = new();

    [SetUp]
    public void Setup()
    {
        uniqueList = new();
        ListsTests.FillList(uniqueList);
    }

    [Test]
    public void PushAlreadyExistingShouldException()
    {
        Assert.Throws<ElementAlreadyExistException>(() => uniqueList.Push(0));
        Assert.Throws<ElementAlreadyExistException>(() => uniqueList.Push(4));
    }

    [Test]
    public void InsertAlreadyExistingShouldException()
    {
        Assert.Throws<ElementAlreadyExistException>(() => uniqueList.Insert(3, 5));
    }

    [Test]
    public void ChangeValueToAlreadyExistingShouldException()
    {
        Assert.Throws<ElementAlreadyExistException>(() => uniqueList.ChangeValueByIndex(0, 3));
    }

    [Test]
    public void ChangeValueToTheSameShouldNothingChange()
    {
        uniqueList.ChangeValueByIndex(1, 1);
        Assert.That(uniqueList.Get(1), Is.EqualTo(1));
    }
}
