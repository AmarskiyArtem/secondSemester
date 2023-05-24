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

using TrieLibrary;

/// <summary>
/// Class for LZW (optional with BWT) encode, works with byte[]
/// </summary>
public static class LZWEncoder
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

    private static Trie FillTrieBySingleByteSequences()
    {
        var trie = new Trie();
        for (var i = 0; i < 256; i++)
        {
            trie.Add(new List<byte> { (byte)i });
        }
        return trie;
    }

    /// <summary>
    /// Encode byte[]
    /// </summary>
    /// <param name="data">bytes</param>
    /// <param name="withBWT">Flag whether to use BWT when compressing</param>
    /// <returns>Encoded data</returns>
    public static byte[] Encode(byte[] data, bool withBWT)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }
        if (data.Length == 0)
        {
            throw new ArgumentException("data can't be empty");
        }
        var buffer = new CompressByteBuffer();
        if (withBWT)
        {
            int dataIndex;
            (data, dataIndex) = BWTransform.BWT.FastDirectConversion(data);
            buffer.Data.AddRange(BitConverter.GetBytes(dataIndex));
        }
        var trie = FillTrieBySingleByteSequences();
        var notRecordedSequence = new List<byte>();
        var currentTrieMaxSize = 512;
        const int trieMaxSize = 65536;
        for (var i = 0; i < data.Length; i++)
        {
            var newSequence = new List<byte>(notRecordedSequence) { data[i] };
            if (trie.Contains(newSequence))
            {
                notRecordedSequence = newSequence;
            }
            else
            {
                buffer.AddNumberToData(trie.Get(notRecordedSequence));
                trie.Add(newSequence);
                if (trie.Size == trieMaxSize)
                {
                    trie = FillTrieBySingleByteSequences();
                    currentTrieMaxSize = 512;
                    buffer.CurrentNumberOfBitsPerNumber = 9;
                }
                if (trie.Size == currentTrieMaxSize)
                {
                    buffer.CurrentNumberOfBitsPerNumber++;
                    currentTrieMaxSize *= 2;
                }
                notRecordedSequence.Clear();
                notRecordedSequence.Add(data[i]);
            }
        }
        buffer.AddNumberToData(trie.Get(notRecordedSequence));
        if (buffer.CurrentNumberOfBitsPerNumber != 0)
        {
            buffer.AddByteToData();
        }
        return buffer.Data.ToArray();
    }
}
