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

public static partial class LZWDecoder
{
    /// <summary>
    /// Byte buffer for LZWDecoder
    /// </summary>
    internal class DecompressByteBuffer
    {
        /// <summary>
        /// output
        /// </summary>
        public List<int> Data { get; private set; } = new();

        public int CurrentBitsPerNumber { get; set; } = 9;

        public int CurrentNumber { get; private set; }
        public int BitsInCurrentNumber { get; private set; }

        private const int BitsInByte = 8;

        /// <summary>
        /// Takes byte, adds to current buffer
        /// </summary>
        /// <param name="bt">byte</param>
        /// <returns>return if new number was added to output</returns>
        public bool AddByteToData(byte bt)
        {
            bool wasAdded = false;
            var bits = GetBitsFromByte(bt);
            foreach (var bit in bits)
            {
                CurrentNumber = (CurrentNumber << 1) + bit;
                ++BitsInCurrentNumber;
                if (BitsInCurrentNumber == CurrentBitsPerNumber)
                {
                    AddNumberToData();
                    wasAdded = true;
                }
            }
            return wasAdded;
        }

        private void AddNumberToData()
        {
            Data.Add(CurrentNumber);
            CurrentNumber = 0;
            BitsInCurrentNumber = 0;
        }

        private static byte[] GetBitsFromByte(byte bt)
        {
            var bits = new byte[BitsInByte];
            for (var i = BitsInByte - 1; i >= 0; i--)
            {
                bits[i] = (byte)(bt % 2);
                bt >>= 1;
            }
            return bits;
        }

        /// <summary>
        /// Using for cases if in LZWEncode wasnt enough bits for added (added extra zeros)
        /// </summary>
        /// <param name="bt">last byte</param>
        public void AddLastByteToData(byte bt)
        {
            var bits = BitsOfLastByte(bt);
            foreach (var bit in bits)
            {
                CurrentNumber = (CurrentNumber << 1) + bit;
                ++BitsInCurrentNumber;
                if (BitsInCurrentNumber == CurrentBitsPerNumber)
                {
                    AddNumberToData();
                }
            }
        }

        private byte[] BitsOfLastByte(byte bt)
        {
            var bits = new List<byte>();
            while (bt > 0)
            {
                bits.Add((byte)(bt % 2));
                bt >>= 1;
            }
            while (bits.Count + BitsInCurrentNumber < BitsInByte)
            {
                bits.Add(0);
            }
            bits.Reverse();
            return bits.ToArray();
        }

    }
}