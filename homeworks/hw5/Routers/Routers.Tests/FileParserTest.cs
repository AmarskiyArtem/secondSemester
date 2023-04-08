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

using Routers.Exceptions;

namespace Routers.Tests;

public class FileParserTest
{
    [Test]
    public void CorrectFileShouldCorrectParse()
    {
        var graph = FileParser.GetGraphFromFile(@"../../../TestFiles/CorrectTestFile.txt");
        var rightResult = new Dictionary<(int, int), int>
        {
            { (1, 2), 10 },
            { (1, 3), 5 },
            { (1, 5), 4 },
            { (2, 3), 1 },
            { (2, 4), 3 },
            { (3, 5), 14 },
        };
        Assert.IsTrue(PrimTests.IsEqualDicts(graph, rightResult));
    }

    [Test]
    public void InvaildLinesShouldException()
    {
        Assert.Throws<InvalidLineException>(() => FileParser.GetGraphFromFile(@"../../../TestFiles/IncorrectTestFile.txt"));
    }
}
