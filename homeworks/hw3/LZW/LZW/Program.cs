using LZW;

if (args.Length < 2)
{
    Console.WriteLine("Need more arguments");
}
else
{
    if (args[1] == "--c")
    {
        try
        {
            Console.WriteLine("Zipping...");
            LZWTransform.Compress(args[0]);
            Console.WriteLine("Successfully");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
    }
    else if (args[1] == "--u")
    {
        try
        {
            Console.WriteLine("Unzipping...");
            LZWTransform.Decompress(args[0]);
            Console.WriteLine("Successfully");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
    }
    else
    {
        Console.WriteLine("Incorrect argument");
    }
}