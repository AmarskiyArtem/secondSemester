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
        => Regex.IsMatch(line, @"\d+: (\d+ \(\d+\),? ?)+");

    public static LinkedList<(int, LinkedList<(int, int)>)> ParseFile(string path)
    {
        var result = new LinkedList<(int, LinkedList<(int, int)>)>();
        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            if (!IsCorrectLine(line))
            {
                throw new IncorrectLineException($"{line} does not match the pattern");
            }
        }
        return result;
    }


}
