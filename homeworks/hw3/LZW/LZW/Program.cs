using LZW;

//LZWTransform.Decompress(@"D:\download\whiteboard-master\whiteboard-master\nbviewer\notebooks\data\harrypotter\Book 1 - The Philosopher's Stone.txt.zipped");
//LZWTransform.Compress(@"D:\tests\logo.png");


var data1 = File.ReadAllBytes(@"D:\tests\logo.png.zipped");
var data2 = File.ReadAllBytes(@"D:\tests\yy\logo.png.zipped");
Console.ReadKey();