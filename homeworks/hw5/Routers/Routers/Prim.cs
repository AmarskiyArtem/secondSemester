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
        if (edges.Count == 0)
        {
            throw new Exceptions.EmptyGraphException();
        }
        if (edges.Count == 1)
        {
            return edges;
        }
        var resultEdges = new Dictionary<(int, int), int>();
        var maxWeightEdge = 0;
        (int, int) maxWeightEdgeVertexes = (0, 0);
        foreach (var edge in edges)
        {
            if (edge.Value > maxWeightEdge)
            {
                maxWeightEdge = edge.Value;
                maxWeightEdgeVertexes = edge.Key;
            }
        }
        resultEdges.Add(maxWeightEdgeVertexes, maxWeightEdge);
        while (true)
        {
            var possibleEdges = GetListOfPotentialEdges(edges, resultEdges);
            if (possibleEdges.Count == 0)
            {
                break;
            }
            var nextEdge = GetNextEdge(possibleEdges);
            resultEdges.Add(nextEdge.Item1, nextEdge.Item2);
        }
        if (resultEdges.Count != GetNumberOfVertexes(edges) - 1)
        {
            throw new Exceptions.DisconnectedGraphException();
        }
        return resultEdges;
    }

    private static ((int, int), int) GetNextEdge(List<((int, int), int)> potentitalEdges)
    {
        var maxWeightEdge = 0;
        (int, int) maxWeightEdgeVertexes = (0, 0);
        foreach (var pair in potentitalEdges)
        {
            if (pair.Item2 > maxWeightEdge)
            {
                maxWeightEdge = pair.Item2;
                maxWeightEdgeVertexes = pair.Item1;
            }
        }
        return (maxWeightEdgeVertexes, maxWeightEdge);
    }

    private static List<((int, int), int)> GetListOfPotentialEdges(Dictionary<(int, int), int> edges,
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
    
    private static int GetNumberOfVertexes(Dictionary<(int, int), int> edges)
    {
        var vertexes = new HashSet<int>();
        foreach (var edge in edges.Keys)
        {
            vertexes.Add(edge.Item1);
            vertexes.Add(edge.Item2);
        }
        return vertexes.Count;
    }
}
