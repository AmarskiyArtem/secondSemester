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
/// Linked list which contains only unique elements
/// </summary>
public class UniqueList : List
{
    private bool Contains(int value)
    {
        var currentNode = Head;
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

    /// <inheritdoc/>
    /// <exception cref="ElementAlreadyExistException"></exception>
    public new void Push(int value)
    {
        if (Contains(value))
        {
            throw new ElementAlreadyExistException($"{value} already added to the unique list");
        }
        base.Push(value);
    }

    /// <inheritdoc/>
    /// <exception cref="ElementAlreadyExistException"></exception>
    public new void Insert(int value, int index)
    {
        if (Contains(value)) 
        {
            throw new ElementAlreadyExistException($"{value} already added to the unique list");
        }
        base.Insert(value, index);
    }

    /// <inheritdoc/>
    /// <exception cref="ElementAlreadyExistException"></exception>
    public new void ChangeValueByIndex(int value, int index)
    {
        if (!Contains(value))
        {
            base.ChangeValueByIndex(value, index);
        }
        else if (Get(index) == value)
        {
            return;
        }
        throw new ElementAlreadyExistException($"{value} already added to the unique list");
    }
}
