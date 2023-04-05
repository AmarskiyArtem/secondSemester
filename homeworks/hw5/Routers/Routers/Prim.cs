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

namespace Routers;

/// <summary>
/// Implementation of Prim's algorithm - greedy algorithm that finds a minimum (maximal) spanning tree for a weighted undirected graph.
/// In this implementation finds maximal.
/// </summary>
public static class Prim
{
    public static Dictionary<(int, int), int> GetMaximalSpanningTree(Dictionary<(int, int), int> edges)
    {
        var resultEdges = new Dictionary<(int, int), int>();
        var maxWeightEdge = 0;
        (int, int) maxWeightEdgeVertexes = (0, 0);
        foreach (KeyValuePair<(int, int), int> pair in edges)
        {
            if (pair.Value > maxWeightEdge)
            {
                maxWeightEdge = pair.Value;
                maxWeightEdgeVertexes = pair.Key;
            }
        }
        resultEdges.Add(maxWeightEdgeVertexes, maxWeightEdge);
        return null;
    }

    //private static ((int, int), int) GetNextEdge(Dictionary<(int, int), int> edges,
    //    Dictionary<(int, int), int> currentEdgesInSpanningTree)
    //{

    //}

    public static List<((int, int), int)> GetListOfPotentialEdges(Dictionary<(int, int), int> edges,
        Dictionary<(int, int), int> currentEdgesInSpanningTree)
    {
        var vertexesInCurrentEdges = new HashSet<int>();
        foreach(var vertexes in currentEdgesInSpanningTree.Keys)
        {
            vertexesInCurrentEdges.Add(vertexes.Item1);
            vertexesInCurrentEdges.Add(vertexes.Item2);
        }
        var potentialEdges = new List<((int, int), int)>();
        foreach (var vertexes in edges.Keys)
        {
            if (vertexesInCurrentEdges.Contains(vertexes.Item1) ^ vertexesInCurrentEdges.Contains(vertexes.Item2))
            {
                potentialEdges.Add((vertexes, edges[vertexes]));
            }
        }
        return potentialEdges;
    }
}
