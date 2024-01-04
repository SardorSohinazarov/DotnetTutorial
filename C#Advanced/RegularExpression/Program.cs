// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

Regex regex = new Regex("^abc$");

Console.WriteLine(regex.IsMatch("abc"));
Console.WriteLine(regex.IsMatch("abcde"));
Console.WriteLine(regex.IsMatch("abcdefg"));
