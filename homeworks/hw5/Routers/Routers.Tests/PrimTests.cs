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

public class PrimTests
{
    public static bool IsEqualDicts(Dictionary<(int, int), int> first, Dictionary<(int, int), int> second)
    {
        foreach (var kvp in first)
        {
            if (second[kvp.Key] != kvp.Value)
            {
                return false;
            }
        }
        return first.Count == second.Count;
    }

    [Test]
    public void ConnectedGraphShouldRightSpanningTree()
    {
        var graph = new Dictionary<(int, int), int>()
        {
            { (1, 4), 15 },
            { (1, 3), 4 },
            { (1, 2), 3 },
            { (2, 4), 8 },
            { (2, 5), 10 },
            { (3, 5), 11 },
            { (4, 5), 30 },
        };
        var rightSpanningTree = new Dictionary<(int, int), int>()
        {
            { (1, 4), 15 },
            { (3, 5), 11 },
            { (2, 5), 10 },
            { (4, 5), 30 },
        };
        var spanningTree = Prim.GetMaximalSpanningTree(graph);
        Assert.IsTrue(IsEqualDicts(spanningTree, rightSpanningTree));
    }
    
    [Test]
    public void EmptyGraphShouldException()
    {
        Assert.Throws<EmptyGraphException>(() => Prim.GetMaximalSpanningTree(new Dictionary<(int, int), int>()));
    }

    [Test]
    public void DisconnectedGraphShouldException()
    {
        var disconnectedGraph = new Dictionary<(int, int), int>()
        {
            { (1, 2), 34 },
            { (2, 7), 32 },
            { (4, 3), 345 },
            { (3, 8), 11 },
            { (4, 6), 132 },
            { (2, 5), 312 },
            { (5, 7), 33 },
        };
        Assert.Throws<DisconnectedGraphException>(() => Prim.GetMaximalSpanningTree(disconnectedGraph));
    }
}