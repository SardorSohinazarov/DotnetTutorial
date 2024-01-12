using Newtonsoft.Json.Linq;

namespace Homework
{
    class Program
    {
        public class HelloBank
        {
            public HelloBank()
            {
                IntroWindow();
                ActionExchange();
            }
            //variables
            public string JsonData;
            public DateTime LastUpdateDate = DateTime.Now;
            public List<string> ValyutaCodes = new List<string>();
            public Dictionary<string, string> ValyutaCosts = new Dictionary<string, string>();
            public ConsoleKeyInfo key;

            #region HttpSetup
            public void HttpSetup()
            {
                string path = "C:/Abu Programmiy/JsonData.json";
                bool offline = false;
                bool OnlineAgain = false;
                try
                {
                    HttpClient httpClient = new HttpClient();
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://nbu.uz/en/exchange-rates/json");
                    HttpResponseMessage response = httpClient.Send(request);
                    JsonData = response.Content.ReadAsStringAsync().Result;
                }
                catch
                {
                    offline = true;
                    if (File.Exists(path))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("Siz internetga ulanmagansiz!\nJoriy Valyuta kursini kora olmaysiz\nLekn sizning kompyuteringizdan saqlangan eski kurs malumotalardan foydalanamiz,\nva u kurslar joriy kurslardan farqli bolishi mumkin!\n\nDavom etish -> ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Enter");
                        key = Console.ReadKey();
                        if (!(key.Key == ConsoleKey.Enter || key.KeyChar == '\u000D'))
                            Environment.Exit(0);
                        JsonData = File.ReadAllText(path);
                        OnlineAgain = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Dastur ishlashi uchun hech bolmasa\nbirinchi marotaba ishga tushirayotganingizda\ninternetga ulangan bolishingiz kerak!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Environment.Exit(0);
                    }
                }
                if (!offline)
                {
                    if (!File.Exists(path))
                    {
                        Directory.CreateDirectory("C:/Abu Programmiy");
                        using (File.Create(path)) ;
                        #region Reklama
                        using (File.Create("C:/Abu Programmiy/ME.txt")) ;
                        File.WriteAllText("C:/Abu Programmiy/ME.txt", "Menga obuna bo'lishni unutmang!\n\nTelegram:  Abu_Programmiy\nYouTube:  Abu_Programmiy\nLinkedIN:  Abu_Programmiy\nGitHub:  Abu_Programmiy");
                        #endregion
                    }
                    File.WriteAllText(path, JsonData);
                }
                if (OnlineAgain && offline == false)
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Siz yana onlinesiz\nJoriy valyutalarga ega boldingiz!");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Davom Etish --> ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Enter");
                        key = Console.ReadKey();
                        if (key.KeyChar == '\u000D')
                            break;
                    }

                }

                JArray Models = JArray.Parse(JsonData);
                foreach (JObject i in Models)
                {
                    ValyutaCodes.Add((string)i["code"]);
                    ValyutaCosts.Add((string)i["code"], (string)i["cb_price"]);
                }
            }
            #endregion
            #region Intro

            public void IntroWindow()
            {
                string HnewLine = new string('\n', 10);
                string Hspaces = new string(' ', 55);
                string TnewLine = new string('\n', 3);
                string Tspaces = new string(' ', 52);
                string Sspaces = new string(' ', 51);
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{HnewLine}{Hspaces}HelloBank");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{TnewLine}{Tspaces}Tab -> to change\n{Tspaces}^ v -> to choose\n\n{Sspaces}press Enter to start");
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter || key.KeyChar == '\u000D')
                    {
                        Console.Clear(); return;
                    }
                    Console.Clear();
                }
            }
            #endregion  
            public void ActionExchange()
            {
                #region variables
                string[] Valyuta1;
                string[] Valyuta2;
                string newLines = new string('\n', 10);
                string spaces = new string(' ', 50);
                string smallSpaces = new string(' ', 5);
                int i = 0;
                int v1 = 0; int v2 = 0;
                string FirstInput = "0";
                string SecondInput = "0";
                char keynNum;
                int j1;
                int j2;
                Decimal Miqdor;
                Decimal Joriy;
                Decimal Next;
                DateTime StartTime = DateTime.Now;
                DateTime CurrentTime;
                #endregion
                #region Update 
                void Update()
                {
                    Console.WriteLine("updating data\nplease wait...");
                    HttpSetup();
                    Valyuta1 = new string[ValyutaCodes.Count + 3];
                    Valyuta2 = new string[ValyutaCodes.Count + 3];
                    Valyuta1[0] = "   ";
                    Valyuta2[0] = "   ";
                    for (int i = 1; i <= ValyutaCodes.Count; i++)
                    {
                        Valyuta1[i] = ValyutaCodes[i - 1];
                        Valyuta2[i] = ValyutaCodes[i - 1];
                    }
                    Valyuta1[Valyuta1.Length - 2] = "UZS";
                    Valyuta2[Valyuta2.Length - 2] = "UZS";

                    Valyuta1[Valyuta1.Length - 1] = "   ";
                    Valyuta2[Valyuta2.Length - 1] = "   ";
                    Console.Clear();
                }
                Update();
                #endregion

                #region Tanlash Menusi
                while (true)
                {
                    CurrentTime = DateTime.Now;
                    #region Menuni korsatish
                    if (i % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"{newLines}{spaces}{smallSpaces}Convert\n\n");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"{spaces} {Valyuta1[v1]}");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{spaces}[{Valyuta1[v1 + 1]}]");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("  -->  ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($"{FirstInput}\n");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"{spaces} {Valyuta1[v1 + 2]}");

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n{spaces} {Valyuta2[v2 + 1]}");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("   -->  ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($"{SecondInput}\n");
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"{newLines}{spaces}{smallSpaces}Convert\n\n");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n{spaces} {Valyuta1[v1 + 1]}");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("   -->  ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($"{FirstInput}\n");

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"\n{spaces} {Valyuta2[v2]}");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{spaces}[{Valyuta1[v2 + 1]}]");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("  -->  ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write($"{SecondInput}\n");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"{spaces} {Valyuta1[v2 + 2]}");
                    }
                    #endregion
                    #region Keyni oqish
                    key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.Tab: i++; break;
                        case ConsoleKey.DownArrow:
                            if (i % 2 == 0 && v1 < Valyuta1.Length - 3)
                                v1++;
                            else if (i % 2 == 1 && v2 < Valyuta2.Length - 3)
                                v2++;
                            break;

                        case ConsoleKey.UpArrow:
                            if (i % 2 == 0 && v1 > 0)
                                v1--;
                            else if (i % 2 == 1 && v2 > 0)
                                v2--;
                            break;
                    }
                    j1 = v1; j2 = v2;
                    keynNum = key.KeyChar;
                    string JoriyInput = i % 2 == 0 ? FirstInput : SecondInput;
                    if (char.IsDigit(keynNum) || keynNum == '.' || key.Key == ConsoleKey.Backspace)
                    {
                        if (JoriyInput.Length < 20)
                        {
                            switch (keynNum)
                            {
                                case '0':
                                    if (JoriyInput != "0")
                                        JoriyInput += "0"; break;
                                case '1':
                                    if (JoriyInput == "0")
                                        JoriyInput = "";
                                    JoriyInput += '1'; break;
                                case '2':
                                    if (JoriyInput == "0")
                                        JoriyInput = "";
                                    JoriyInput += '2'; break;
                                case '3':
                                    if (JoriyInput == "0")
                                        JoriyInput = "";
                                    JoriyInput += '3'; break;
                                case '4':
                                    if (JoriyInput == "0")
                                        JoriyInput = "";
                                    JoriyInput += '4'; break;
                                case '5':
                                    if (JoriyInput == "0")
                                        JoriyInput = "";
                                    JoriyInput += '5'; break;
                                case '6':
                                    if (JoriyInput == "0")
                                        JoriyInput = "";
                                    JoriyInput += '6'; break;
                                case '7':
                                    if (JoriyInput == "0")
                                        JoriyInput = "";
                                    JoriyInput += '7'; break;
                                case '8':
                                    if (JoriyInput == "0")
                                        JoriyInput = "";
                                    JoriyInput += '8'; break;
                                case '9':
                                    if (JoriyInput == "0")
                                        JoriyInput = "";
                                    JoriyInput += '9'; break;
                                case '.':
                                    if (!JoriyInput.Contains("."))
                                        JoriyInput += "."; break;
                            }
                        }

                        if (key.Key == ConsoleKey.Backspace)
                        {
                            if (JoriyInput.Length > 0 && JoriyInput != "0")
                                JoriyInput = JoriyInput.Substring(0, JoriyInput.Length - 1);
                            if (JoriyInput.Length == 0)
                                JoriyInput = "0";
                        }
                    }
                    if (i % 2 == 0) FirstInput = JoriyInput;
                    else SecondInput = JoriyInput;
                    #endregion

                    //hisoblash
                    #region hisoblash
                    char last = JoriyInput[JoriyInput.Length - 1];
                    if (last == '.')
                        JoriyInput = JoriyInput.Substring(0, JoriyInput.Length - 1);
                    Miqdor = Decimal.Parse(JoriyInput);
                    if (i % 2 == 0)
                    {
                        if (Valyuta1[j1 + 1] == "UZS")
                            Joriy = 1;
                        else
                            Joriy = Decimal.Parse(ValyutaCosts[Valyuta1[j1 + 1]]);
                        if (Valyuta2[j2 + 1] == "UZS")
                            Next = 1;
                        else
                            Next = Decimal.Parse(ValyutaCosts[Valyuta2[j2 + 1]]);
                        SecondInput = (Joriy * Miqdor / Next).ToString("F2");
                    }
                    if (i % 2 == 1)
                    {
                        if (Valyuta2[j2 + 1] == "UZS")
                            Joriy = 1;
                        else
                            Joriy = Decimal.Parse(ValyutaCosts[Valyuta2[j2 + 1]]);
                        if (Valyuta1[j1 + 1] == "UZS")
                            Next = 1;
                        else
                            Next = Decimal.Parse(ValyutaCosts[Valyuta1[j1 + 1]]);
                        FirstInput = (Joriy * Miqdor / Next).ToString("F2");
                    }
                    #endregion
                    #region Har 3 minutda update qilish
                    /*if ((CurrentTime.TimeOfDay - StartTime.TimeOfDay).Minutes > 3 || (CurrentTime.TimeOfDay - StartTime.TimeOfDay).Minutes < 3)
                        Update();*/
                    #endregion
                    Console.Clear();
                }
                #endregion
            }
        }

        static void Main()
        {
            Console.CursorVisible = false;
            HelloBank helloBank = new HelloBank();
        }
    }
}
//Front-end chiroyli
//umuman exception qaytarmidi
//Offline ham ishlaydi
//Buglari yoq