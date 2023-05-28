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

namespace TrieLibrary;

using System.Collections.Generic;

// An efficiently stored set of bytes
public class Trie
{
    private class TrieNode
    {
        public TrieNode(int value) 
        {
            Value = value;
            Children = new();
        }

        public Dictionary<byte, TrieNode> Children { get; set; } = new();

        public bool IsTerminate { get; set; }

        public int SequencesWithSamePrefix { get; set; }

        public int Value { get; private set; }
    }

    public Trie() { }

    private readonly TrieNode root = new(-1);

    private bool isEmptyStringAdded;

    public int Size { get; private set; }

    // Add sequence to trie. Returns false if the sequence already been added otherwise true
    public bool Add(List<byte> sequence)
    {
        if (sequence.Count == 0)
        {
            if (isEmptyStringAdded)
            {
                return false;
            }
            isEmptyStringAdded = true;
            this.Size++;
            return true;
        }

        if (Contains(sequence))
        {
            return false;
        }

        var node = this.root;
        foreach (var bt in sequence)
        {
            if (!node.Children.ContainsKey(bt))
            {
                node.Children[bt] = new TrieNode(Size);
                Size++;
            }
            node.SequencesWithSamePrefix++;
            node = node.Children[bt];
        }
        node.SequencesWithSamePrefix++;
        node.IsTerminate = true;
        return true;
    }

    // Check if sequence contatins in the trie
    public bool Contains(List<byte> sequence)
    {
        if (sequence.Count == 0)
        {
            return isEmptyStringAdded;
        }

        var node = this.root;
        foreach (var bt in sequence)
        {
            if (!node.Children.ContainsKey(bt))
            {
                return false;
            }
            node = node.Children[bt];
        }
        return node.IsTerminate;
    }

    // Remove element from the trie. Returns true if successful, false if element 
    // is not contained in the trie
    public bool Remove(List<byte> sequence)
    {
        if (sequence.Count == 0)
        {
            if (isEmptyStringAdded)
            {
                isEmptyStringAdded = false;
                return true;
            }
            return false;
        }

        if (!Contains(sequence))
        {
            return false;
        }

        var node = this.root;
        foreach (var bt in sequence)
        {
            node.SequencesWithSamePrefix--;
            node = node.Children[bt];
        }
        node.IsTerminate = false;
        this.Size--;
        return true;
    }

    // Return the value by sequence
    public int Get(List<byte> sequence)
    {
        var node = this.root;
        foreach (var bt in sequence)
        {
            node = node.Children[bt];
        }
        return node.Value;
    }
}