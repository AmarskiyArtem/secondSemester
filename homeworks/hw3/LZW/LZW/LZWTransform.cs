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

namespace LZW;

/// <summary>
/// Class for LZW (with BWT) transform, works with path to files
/// </summary>
public static class LZWTransform
{
    /// <summary>
    /// Takes path to file and creates path.zipped files in same directory
    /// </summary>
    /// <param name="path">path to file</param>
    /// <returns>compressionRatioWithBWT and compressionRatioWithoutBWT</returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static (double compressionRatioWithBWT, double compressionRatioWithoutBWT) Compress(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }
        var data = File.ReadAllBytes(path);
        var compressedDataWithBWT = LZWEncoder.Encode(data, true);
        var compressedDataWithoutBWT = LZWEncoder.Encode(data, false);
        File.WriteAllBytes(path + ".zipped", compressedDataWithBWT);
        return ((double)compressedDataWithBWT.Length / data.Length, (double)compressedDataWithoutBWT.Length / data.Length);
    }

    /// <summary>
    /// Takes path to compressed files, creates decompressed files in same directory
    /// </summary>
    /// <param name="path">path to file</param>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="ArgumentException">if file with not supported format</exception>
    public static void Decompress(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }
        if (!path.EndsWith(".zipped"))
        {
            throw new ArgumentException("Not supported format");
        }
        var compressedData = File.ReadAllBytes(path);
        var data = LZWDecoder.Decode(compressedData);
        File.WriteAllBytes(path[0..(^6)], data);
    }
}
