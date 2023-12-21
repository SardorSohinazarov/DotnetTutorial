Console.CursorVisible = false;
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Green;

string[,] check =
{
    {"1", "2", "3", "4"},
    {"5", "6", "7", "8"},
    {"9", "10", "11", "12"},
    {"13", "14", "15", " "},

};

string[,] nums =
{
    {"6", "5", "11", "1"},
    {"2", " ", "3", "12"},
    {"14", "4", "8", "10"},
    {"6", "15", "2", "13"},
};

int row = 3, col = 3;
bool game = true;

while (game)
{
    for (int i = 0; i < nums.GetLength(0); i++)
    {
        Console.WriteLine("    - - - - - - - - - -    ");
        for (int j = 0; j < nums.GetLength(1); j++)
        {
            if (nums[i, j].Length > 1)
            {
                Console.Write($"|  {nums[i, j]} |");
            }
            else
                Console.Write($"|  {nums[i, j]}  |");
        }
        Console.WriteLine();
    }
    Console.WriteLine("    - - - - - - - - - -    ");


    var key = Console.ReadKey();
    Console.Clear();

    if (key.Key == ConsoleKey.DownArrow)
    {
        Console.Beep(234, 125);
        if (row - 1 >= 0 && row - 1 != 4)
        {
            var temp = nums[row - 1, col];
            nums[row - 1, col] = nums[row, col];
            nums[row, col] = temp;
            row--;
        }
    }
    else if (key.Key == ConsoleKey.UpArrow)
    {
        Console.Beep(450, 648);


        if (row + 1 >= 0 && row + 1 != 4)
        {
            var temp = nums[row + 1, col];
            nums[row + 1, col] = nums[row, col];
            nums[row, col] = temp;
            row++;
        }
    }
    else if (key.Key == ConsoleKey.RightArrow)
    {
        Console.Beep(450, 648);

        if (col - 1 >= 0 && col - 1 != 4)
        {
            var temp = nums[row, col - 1];
            nums[row, col - 1] = nums[row, col];
            nums[row, col] = temp;
            col--;
        }
    }
    else if (key.Key == ConsoleKey.LeftArrow)
    {
        Console.Beep(234, 125);


        if (col + 1 >= 0 && col + 1 != 4)
        {
            var temp = nums[row, col + 1];
            nums[row, col + 1] = nums[row, col];
            nums[row, col] = temp;
            col++;
        }
    }

    if (nums.Cast<string>().SequenceEqual(check.Cast<string>()))
    {
        game = false;
        Console.Clear();
        Console.WriteLine("Winner!");
    }
}