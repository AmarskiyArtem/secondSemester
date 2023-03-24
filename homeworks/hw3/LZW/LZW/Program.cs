using LZW;
using System.Runtime.Serialization.Formatters;

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
//            LZWTransform.Compress(args[0]);
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
//        catch (FileNotFoundException)
//        {
//            Console.WriteLine("File not found");
//        }
//    }
//    else
//    {
//        Console.WriteLine("Incorrect argument");
//    }
//}


//LZWTransform.Compress(@"D:\games\Vampire.Survivors.Build.10331827\VampireSurvivors.exe");
//LZWTransform.Decompress(@"D:\games\Vampire.Survivors.Build.10331827\VampireSurvivors.exe.zipped");
//LZWTransform.Compress(@"D:\tests\TextDocument.txt");
//LZWTransform.Decompress(@"D:\tests\TextDocument.txt.zipped");
//LZWTransform.Decompress(@"D:\tests\TextDocument.txt.zipped");

//LZWTransform.Compress(@"D:\tests\Screenshot 2023-03-15 204216.png");
//LZWTransform.Decompress(@"D:\tests\Screenshot 2023-03-15 204216.png.zipped");

var data1 = File.ReadAllBytes(@"D:\tests\Screenshot 2023-03-15 204216.png");
var data2 = File.ReadAllBytes(@"C:\Users\AmarskiyArtem\Pictures\Screenshots\Screenshot 2023-03-15 204216.png");

//for (var i = 0; i < data1.Length; i++)
//{
//    if (data1[i] != data2[i])
//    {
//        Console.WriteLine("Bad");
//        Console.ReadKey();
//    }
//}

for (var i = 0; i < data2.Length; i++)
{
    if (data1[i] != data2[i])
    {
        Console.WriteLine("Bad");
        Console.ReadKey();
    }
}
Console.WriteLine("Nice");
//for (int i = 535510;  i < data1.Length; i++)
//{
//    Console.Write(data1[i] + " ");
//}

//Console.WriteLine();

//for (int i = 535510; i < data2.Length; i++)
//{
//    Console.Write(data2[i] + " ");
//}