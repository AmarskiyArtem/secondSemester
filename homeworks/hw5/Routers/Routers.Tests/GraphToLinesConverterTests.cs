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

namespace Routers.Tests;

public class GraphToLinesConverterTests
{
    [Test]
    public void GraphShouldRightArray()
    {
        var graph = new Dictionary<(int, int), int>()
        {
            { (1, 4), 15 },
            { (3, 5), 11 },
            { (2, 5), 10 },
            { (4, 5), 30 },
        };
        var result = GraphToLinesConverter.GetLinesFromGraph(graph);
        var rightResult = new string[] { "1: 4 (15)", "3: 5 (11)", "2: 5 (10)", "4: 5 (30)" };
        Assert.That(result, Is.EqualTo(rightResult));
    }

    [Test]
    public void EmptyGraphShouldNormalReaction()
    {
        Assert.That(GraphToLinesConverter.GetLinesFromGraph(new Dictionary<(int, int), int>()), Is.EqualTo(new string[0]));
    }
}
