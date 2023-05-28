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

using Routers;
using Routers.Exceptions;

if (args.Length != 2)
{
    Console.Error.WriteLine("Invalid number of arguments");
    return -1;
}

Dictionary<(int, int), int> graph;
try
{
    graph = FileParser.GetGraphFromFile(args[0]);
}
catch (Exception e) when (e is FileNotFoundException || e is InvalidLineException)
{
    Console.Error.WriteLine(e.Message);
    return -1;
}

Dictionary<(int, int), int> spanningTree;
try
{
    spanningTree = Prim.GetMaximalSpanningTree(graph);
}
catch (Exception e) when (e is EmptyGraphException || e is DisconnectedGraphException)
{
    Console.Error.WriteLine(e.Message);
    return -1;
}

var resultLines = GraphToLinesConverter.GetLinesFromGraph(spanningTree);
File.WriteAllLines(args[1], resultLines);
return 0;