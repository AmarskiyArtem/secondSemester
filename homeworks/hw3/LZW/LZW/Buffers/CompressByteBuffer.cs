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

public static partial class LZWEncoder
{
    /// <summary>
    /// Byte buffer for LZWEncoder
    /// </summary>
    private class CompressByteBuffer
    {
        /// <summary>
        /// output
        /// </summary>
        public List<byte> Data { get; private set; } = new();

        public int CurrentNumberOfBitsPerNumber { get; set; } = 9;

        public byte CurrentByte { get; private set; } = 0;

        private int bitsInCurrentByte = 0;

        private const int BitsInByte = 8;

        /// <summary>
        /// Adds number to output
        /// </summary>
        /// <param name="number"></param>
        public void AddNumberToData(int number)
        {
            var bits = GetBitsFromNumber(number);
            foreach (var bit in bits)
            {
                CurrentByte = (byte)((CurrentByte << 1) + bit);
                bitsInCurrentByte++;
                if (bitsInCurrentByte == BitsInByte)
                {
                    AddByteToData();
                }
            }
        }

        /// <summary>
        /// Add current byte to output
        /// </summary>
        public void AddByteToData()
        {
            Data.Add(CurrentByte);
            CurrentByte = 0;
            bitsInCurrentByte = 0;
        }

        private byte[] GetBitsFromNumber(int number)
        {
            var bits = new byte[CurrentNumberOfBitsPerNumber];
            for (var i = CurrentNumberOfBitsPerNumber - 1; i >= 0; i--)
            {
                bits[i] = (byte)(number % 2);
                number >>= 1;
            }
            return bits;
        }
    }
}