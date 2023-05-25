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

namespace UniqueListLibrary;

/// <summary>
/// Linked list, a linear collection of int
/// </summary>
public class List
{
    private class ListElement
    {
        public ListElement(int value, ListElement? next)
        {
            Value = value;
            Next = next;
        }
        public int Value { get; set; }
        public ListElement? Next { get; set; }
    }

    /// <summary>
    /// Number of elements in list
    /// </summary>
    public int Size { get; private set; }

    private ListElement? head;

    /// <summary>
    /// Add new element with given value to the head of list
    /// </summary>
    public void Push(int value)
    {
        var newHead = new ListElement(value, head);
        head = newHead;
        Size++;
    }

    /// <summary>
    /// Returns value that lies at given index
    /// </summary>
    public int Get(int index)
    {
        if (index >= Size || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        var currentListElement = getByIndex(index);
        return currentListElement.Value;
    }
    
    /// <summary>
    /// Insert new element with given value before element with given index
    /// </summary>
    public void Insert(int value, int index)
    {
        if (index > Size || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            Push(value);
            return;
        }

        var currentListElement = getByIndex(index - 1);
        var newElement = new ListElement(value, currentListElement.Next);
        currentListElement.Next = newElement;
        Size++;
    }

    /// <summary>
    /// Changes the value for given index
    /// </summary>
    public void ChangeValueByIndex(int value, int index)
    {
        if (index >= Size || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        var currentListElement = getByIndex(index);
        currentListElement.Value = value;
    }

    /// <summary>
    /// Remove element with given index from list
    /// </summary>
    public void Remove(int index) 
    {
        if (index >= Size || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            head = head!.Next;
        }

        var currentListElement = getByIndex(index - 1);        
        if (currentListElement.Next is null)
        {
            throw new InvalidOperationException();
        }
        currentListElement.Next = currentListElement.Next.Next;
        Size--;
    }

    /// <summary>
    /// Checks whether the value is contained in the list
    /// </summary>
    public bool Contains(int value)
    {
        var currentNode = head;
        while (currentNode != null)
        {
            if (currentNode.Value == value)
            {
                return true;
            }
            currentNode = currentNode.Next;
        }
        return false;
    }

    private ListElement getByIndex(int index)
    {
        var currentListElement = head;
        for (var i = 0; i < index; i++)
        {
            if (currentListElement is null)
            {
                throw new InvalidOperationException();
            }
            currentListElement = currentListElement.Next;
        }
        if (currentListElement is null) 
        {
            throw new InvalidOperationException();
        }
        return currentListElement;
    }
}