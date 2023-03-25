//using LZW;

//if (args.Length < 2)
//{
//    Console.WriteLine("Need more arguments");
//}
//else
//{
//    if (args[1] == "--c")
//    {
//        try
//        {
//            Console.WriteLine("Zipping...");
//            var (compressionRatioWithBWT, compressionRatioWithoutBWT) = LZWTransform.Compress(args[0]);
//            Console.WriteLine($"compression ratio with BWT {compressionRatioWithBWT}");
//            Console.WriteLine($"compression ratio without BWT {compressionRatioWithoutBWT}");
//            Console.WriteLine("Successfully");
//        }
//        catch (FileNotFoundException)
//        {
//            Console.WriteLine("File not found");
//        }
//    }
//    else if (args[1] == "--u")
//    {
//        try
//        {
//            Console.WriteLine("Unzipping...");
//            LZWTransform.Decompress(args[0]);
//            Console.WriteLine("Successfully");
//        }
//        catch (FileNotFoundException e)
//        {
//            Console.WriteLine($"{e.Message}");
//        }
//        catch (ArgumentException e)
//        {
//            Console.WriteLine($"{e.Message}"); 
//        }
//    }
//    else
//    {
//        Console.WriteLine("Incorrect argument");
//    }
//}

Console.WriteLine(Enumerable.SequenceEqual(File.ReadAllBytes(@"D:\tests\FallGuys_client_game.exe"), File.ReadAllBytes(@"D:\games\steamapps\common\Fall Guys\FallGuys_client_game.exe")));