using ParsingTreeLibrary;

var tree = new ParsingTree("+ 45 43 34");

tree.PrintTree();
Console.WriteLine();
Console.WriteLine(tree.CalculateTree());