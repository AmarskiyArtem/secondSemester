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

using TrieHomework;

static void PrintActions()
{
    Console.WriteLine("0 - exit\n1 - add\n2 - check if contains\n3 - remove\n" +
            "4 - count how many words with this prefix\n" +
            "5 - find out the number of words in trie\n6 - print actions again");
}

var trie = new Trie();
var isContinue = true;
PrintActions();
while (isContinue)
{
    Console.WriteLine("Input action");
    var action = Console.ReadLine();
    switch (action)
    {
        case "0":
            {
                isContinue = false;
                Console.WriteLine("Good bye!");
                break;
            }
        case "1":
            {
                Console.WriteLine("Input a word");
                var word = Console.ReadLine();
                if (word == null)
                {
                    Console.WriteLine("Input can't be null");
                    break;
                }
                Console.WriteLine(trie.Add(word) ? "Successfully added" : "Already added");
                break;
            }
        case "2":
            {
                Console.WriteLine("Input a word");
                var word = Console.ReadLine();
                if (word == null)
                {
                    Console.WriteLine("Input can't be null");
                    break;
                }
                Console.WriteLine(trie.Contains(word) ? "Contains" : "Not contains");
                break;
            }
        case "3":
            {
                Console.WriteLine("Input a word");
                var word = Console.ReadLine();
                if (word == null)
                {
                    Console.WriteLine("Input can't be null");
                    break;
                }
                Console.WriteLine(trie.Remove(word) ? "Successfully removed" : "Not contains");
                break;
            }
        case "4":
            {
                Console.WriteLine("Input a prefix");
                var prefix = Console.ReadLine();
                if (prefix == null)
                {
                    Console.WriteLine("Input can't be null");
                    break;
                }
                Console.WriteLine($"{trie.HowManyStartsWithPrefix(prefix)} words with that prefix");
                break;
            }
        case "5":
            {
                Console.WriteLine($"{trie.Size} - total number of words in trie");
                break;
            }
        case "6":
            {
                PrintActions();
                break;
            }
        default:
            {
                Console.WriteLine("Wrong input");
                break;
            }
    }
}

