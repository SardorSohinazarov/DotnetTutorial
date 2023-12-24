


/*// See https://aka.ms/new-console-template for more information
using Delegates;
using System;
*//*Methods methods = new Methods();

#region Action
*//*
Action action = () => methods.SalomBer();

action += () =>
{
    string name = Console.ReadLine();
    Console.WriteLine(name);
};

methods.Start(action);


Action<int> action1 = new Action<int>(num => Console.WriteLine(num));

void Nechchi(int num)
{
    Console.WriteLine(num);
}

action1 += Nechchi;*//*
#endregion

#region Func

Func<int> func = new Func<int>(methods.RaqamBer);

Console.WriteLine(func.Invoke());
#endregion

#region Predicate
Predicate<int> predicate = num => methods.MantiqBer(num);

predicate.Invoke(7);
#endregion
*//*
#region Event

#endregion*/