/*// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] myArray = new int[10] {1,2,3,4,5,6,7,8,9,10};
foreach (int i in myArray)
    Console.WriteLine(i);

Console.WriteLine(myArray.GetHashCode());
Array.Resize(ref myArray, 11);
myArray[10] = 11;
Console.WriteLine(myArray.GetHashCode());

foreach (int i in myArray)
    Console.WriteLine(i);


Console.WriteLine(myArray.Length);

*/

string myString = "Sardor";

var a = myString.Reverse();


Console.WriteLine(myString.Replace("r","{bu r harfi}"));

Console.WriteLine(myString[2..4]);