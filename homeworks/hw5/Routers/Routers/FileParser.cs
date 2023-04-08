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

using System.Text.RegularExpressions;

public static class FileParser
{

    private static bool IsCorrectLine(string line)
        => Regex.IsMatch(line, @"^\d+: (\d+ \(\d+\),? ?)+$");

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="Exceptions.InvalidLineException"></exception>
    public static Dictionary<(int, int), int> GetGraphFromFile(string path)
    {
        var result = new Dictionary<(int, int), int>();
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }
        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            if (!IsCorrectLine(line))
            {
                throw new Exceptions.InvalidLineException($"{line} does not match the pattern");
            }
            var parsedLine = ParseLine(line);
            foreach (var pairs in parsedLine)
            {
                result.Add(pairs.Item1, pairs.Item2);
            }
        }
        return result;
    }

    private static List<((int, int), int)> ParseLine(string line)
    {
        var parts = line.Split(':');
        var firstVertex = int.Parse(parts[0].Trim());
        var items = parts[1].Split(',');
        var result = new List<((int, int), int)>();

        foreach (var item in items)
        {
            var secondVertex = item.Trim().Split('(');
            var secondVertexNumber = int.Parse(secondVertex[0].Trim());
            var edgeSpeed = int.Parse(secondVertex[1].TrimEnd(')'));
            result.Add(((firstVertex, secondVertexNumber), edgeSpeed));
        }

        return result;
    }
}