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

using LZW;

if (args.Length < 2)
{
    Console.WriteLine("Need more arguments");
}
else
{
    if (args[1] == "--c")
    {
        try
        {
            Console.WriteLine("Zipping...");
            var (compressionRatioWithBWT, compressionRatioWithoutBWT) = LZWTransform.Compress(args[0]);
            Console.WriteLine($"compression ratio with BWT {compressionRatioWithBWT}");
            Console.WriteLine($"compression ratio without BWT {compressionRatioWithoutBWT}");
            Console.WriteLine("Successfully");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
    }
    else if (args[1] == "--u")
    {
        try
        {
            Console.WriteLine("Unzipping...");
            LZWTransform.Decompress(args[0]);
            Console.WriteLine("Successfully");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"{e.Message}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }
    else
    {
        Console.WriteLine("Incorrect argument");
    }
}