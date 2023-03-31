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

namespace TrieLibraryTests;

using TrieHomework;

// If you somehow got here. Please, dont read it. AND NEVER TRY TO USE IT.
// If you want to see how I write unit tests, you can do it in any other task
public class TrieTest
{
    [Test]
    public void LonelyTest()
    {
        Trie testTrie = new();
        Assert.That(testTrie.Add("Cat"), Is.True);
        Assert.That(testTrie.Add("Catyy"), Is.True);
        Assert.That(testTrie.Add("CatLand"), Is.True);
        Assert.That(testTrie.Add("SomeAnotherPrefix"), Is.True);
        Assert.That(testTrie.Size, Is.EqualTo(4));
        Assert.IsTrue(testTrie.Contains("Catyy"));
        Assert.IsFalse(testTrie.Contains("WordWhichDontExist"));
        Assert.That(testTrie.HowManyStartsWithPrefix("Cat"), Is.EqualTo(3));
        Assert.That(testTrie.HowManyStartsWithPrefix("Soma"), Is.EqualTo(0));
        Assert.IsTrue(testTrie.Remove("Cat"));
        Assert.IsFalse(testTrie.Remove("Cat"));
        Assert.That(testTrie.Size, Is.EqualTo(3));
        Assert.That(testTrie.HowManyStartsWithPrefix("Ca"), Is.EqualTo(2));
    }
}