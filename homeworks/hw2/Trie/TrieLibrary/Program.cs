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

