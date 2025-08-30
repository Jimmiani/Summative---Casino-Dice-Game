namespace Summative___Casino_Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cash = 10;
            bool done = false;
            string choice = "";
            Console.SetWindowSize(150, 40);


            // Lists
            //---------------------------

            // Menu

            List<string> instructions = new List<string>();
            instructions.Add(new string("Welcome to The Devil's Casino – a place where luck is not just chance, and every roll has a cost. The dealer"));
            instructions.Add(new string("smiles, but the cards of fate are marked, and the dice whisper secrets of losses yet to come. Win, and you might"));
            instructions.Add(new string("leave with more than you arrived. Lose, and the house will take... what it's owed. Step inside. The stakes are"));
            instructions.Add(new string("higher than your soul can afford."));

            List <string> options = new List<string>();
            options.Add(new string("Option 1: Play the Casino"));
            options.Add(new string("Option 2: How to Play"));
            options.Add(new string("Option 3: Quit "));

            // Casino

            List <string> casinoBets = new List<string>();
            casinoBets.Add(new string("Option 1: Doubles (2X Bet)"));
            casinoBets.Add(new string("Option 2: Not Doubles (0.5X Bet)"));
            casinoBets.Add(new string("Option 3: Even Sum (1X Bet)"));
            casinoBets.Add(new string("Option 4: Odd Sum (1X Bet)"));
            casinoBets.Add(new string("Option 5: Snake Eyes (10X Bet)"));
            casinoBets.Add(new string("Option 6: Sum of 7 (2X Bet)"));
            casinoBets.Add(new string("Option 7: Sum of 3 (4X Bet)"));

            List<string> neutralCasino = new List<string>();
            neutralCasino.Add(new string("The dealer's ready. The dice are waiting."));
            neutralCasino.Add(new string("The air is heavy with chance. Care to tempt fate?"));
            neutralCasino.Add(new string("The dice have no mercy. Shall we begin?"));
            neutralCasino.Add(new string("The Devil watches, amused by your desperation."));

            List <string> losingCasino = new List<string>();
            losingCasino.Add(new string("The dice smell fear. Care to feed them?"));
            losingCasino.Add(new string("You're running out of chips... and chances."));
            losingCasino.Add(new string("Running low? The house loves a desperate player."));
            losingCasino.Add(new string("The house collects. It always does."));

            List<string> winningCasino = new List<string>();
            winningCasino.Add(new string("The dice seem to like you... for now."));
            winningCasino.Add(new string("You're winning... the house hates that."));
            winningCasino.Add(new string("You've cheated fate... or has fate chosen to let you?"));
            winningCasino.Add(new string("The Devil smiles... but not kindly. Fortune favors you -- for now."));

            //---------------------------

            // Strings
            //---------------------------

            // Menu

            string introText = "Welcome to the...";
            string cashText = $"Your cash: {cash.ToString("C")}";
            string underline = "----------------------------";

            // Casino

            string enterBet = "Seven paths, some lead to fortune... others to none. Choose your fate.";
            string betUnderline = "----------------------------------------------------------------------";

            //---------------------------

            while (!done)
            {
                int y = 2;
                cashText = $"Your cash: {cash.ToString("C")}";
                Console.Clear();
                CentreText(introText, y); y += 2;
                IntroText(y, ConsoleColor.DarkRed); y += 10;    
                CentreText(cashText, y); y++;
                CentreText(underline, y); y += 2;
                CentreText(instructions, y); y += instructions.Count + 1;
                CentreText(underline, y); y += 2;
                CentreText(options, y); y += options.Count + 1;
                Console.SetCursorPosition(57, y);
                Console.Write("Enter in your choice here (1 - 3): ");
                choice = Console.ReadLine().Trim();
                while (choice != "1" && choice != "2" && choice != "3")
                {
                    y++;
                    Console.SetCursorPosition(61, y);
                    Console.Write("Invalid Input. Try again: ");
                    choice = Console.ReadLine();
                }
                if (choice == "1")
                {
                    while (true)
                    {
                        ConsoleColor casinoColor = ConsoleColor.DarkGray;
                        if (cash == 100)
                        {
                            casinoColor = ConsoleColor.DarkGray;
                        }
                        else if (cash < 100)
                        {
                            casinoColor = ConsoleColor.DarkRed;
                        }
                        else if (cash > 100)
                        {
                            casinoColor = ConsoleColor.Yellow;
                        }
                        CreateBox(142, 35, 4, 2, casinoColor);
                        CustomText(cashText, 128 - cash.ToString().Length, 4, ConsoleColor.Green);
                        if (cash == 100)
                        {
                            CustomText(neutralCasino, 8, 4, casinoColor, true);
                        }
                        else if (cash < 100)
                        {
                            CustomText(losingCasino, 8, 4, casinoColor, true);
                        }
                        else if (cash > 100)
                        {
                            CustomText(winningCasino, 8, 4, casinoColor, true);
                        }
                        CustomText(enterBet, 8, 7, casinoColor);
                        CustomText(betUnderline, 8, 8, casinoColor);
                        CustomText(casinoBets, 8, 11, casinoColor, false);
                        Console.ReadLine();
                    }
                }
                else if (choice == "2")
                {
                    Rules();
                }
                else if (choice == "3")
                {
                    done = true;
                }
            }
        }
        public static void CentreText(string text, int y)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, y);
            Console.WriteLine(text);
        }
        public static void CentreText(List<string> text, int y)
        {
            for (int i = 0; i < text.Count; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - text[i].Length) / 2, y);
                Console.WriteLine(text[i]);
                y++;
            }
        }
        public static void CreateBox(int width, int height, int x, int y, ConsoleColor color)
        {
            for (int i = 0; i <= height; i++)
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(x, y);
                for (int j = 0; j <= width; j++)
                {
                    if (i == 0 || i == height)
                    {
                        if (j == width)
                        {
                            Console.WriteLine("-");
                            y++;
                        }
                        else
                        {
                            Console.Write("-");
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            Console.Write("|");
                        }
                        else if (j == width)
                        {
                            Console.WriteLine("|");
                            y++;
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
            }
            Console.ResetColor();
        }
        public static void CustomText(string text, int x, int y, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void CustomText(List<string> text, int x, int y, ConsoleColor color, bool sleep)
        {
            Random generator = new Random();
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            if (sleep)
            {
                foreach (char c in text[generator.Next(0, text.Count)])
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }
            }
            else
            {
                for (int i = 0; i < text.Count; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(text[i]);
                    y += 2;
                }
            }
            Console.ResetColor();
        }
        public static void IntroText(int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(12, y); y++;
            Console.WriteLine(@" /$$$$$$$  /$$$$$$$$ /$$    /$$ /$$$$$$ /$$ /$$    /$$$$$$         /$$$$$$   /$$$$$$   /$$$$$$  /$$$$$$ /$$   /$$  /$$$$$$  /$$");
            Console.SetCursorPosition(12, y); y++;
            Console.WriteLine(@"| $$__  $$| $$_____/| $$   | $$|_  $$_/| $$| $/   /$$__  $$       /$$__  $$ /$$__  $$ /$$__  $$|_  $$_/| $$$ | $$ /$$__  $$| $$");
            Console.SetCursorPosition(12, y); y++;
            Console.WriteLine(@"| $$  \ $$| $$      | $$   | $$  | $$  | $$|_/   | $$  \__/      | $$  \__/| $$  \ $$| $$  \__/  | $$  | $$$$| $$| $$  \ $$| $$");
            Console.SetCursorPosition(12, y); y++;
            Console.WriteLine(@"| $$  | $$| $$$$$   |  $$ / $$/  | $$  | $$      |  $$$$$$       | $$      | $$$$$$$$|  $$$$$$   | $$  | $$ $$ $$| $$  | $$| $$");
            Console.SetCursorPosition(12, y); y++;
            Console.WriteLine(@"| $$  | $$| $$__/    \  $$ $$/   | $$  | $$       \____  $$      | $$      | $$__  $$ \____  $$  | $$  | $$  $$$$| $$  | $$|__/");
            Console.SetCursorPosition(12, y); y++;
            Console.WriteLine(@"| $$  | $$| $$        \  $$$/    | $$  | $$       /$$  \ $$      | $$    $$| $$  | $$ /$$  \ $$  | $$  | $$\  $$$| $$  | $$    ");
            Console.SetCursorPosition(12, y); y++;
            Console.WriteLine(@"| $$$$$$$/| $$$$$$$$   \  $/    /$$$$$$| $$$$$$$$|  $$$$$$/      |  $$$$$$/| $$  | $$|  $$$$$$/ /$$$$$$| $$ \  $$|  $$$$$$/ /$$");
            Console.SetCursorPosition(12, y); y++;
            Console.WriteLine(@"|_______/ |________/    \_/    |______/|________/ \______/        \______/ |__/  |__/ \______/ |______/|__/  \__/ \______/ |__/");
            Console.ResetColor();
        }
        public static void Rules()
        {
            int y = 2;
            string intro = "How to Play";
            string underline = "----------------------------";
            string leave = "Press 'ENTER' to return to the main menu";
            List<string> instructions = new List<string>();
            instructions.Add(new string("When playing the casino, you'll be prompted to bet a portion of your cash on the outcome of the roll of two dice."));
            instructions.Add(new string("The possible outcomes you can bet on are listed in the table below."));
            instructions.Add(new string(""));
            instructions.Add(new string("If you bet on the correct outcome, you'll win the amount of money according to the following table. If you lose, you lose your bet."));
            instructions.Add(new string("After you bet your money, you'll see two die appear on screen and what they landed on."));
            instructions.Add(new string("You'll then be informed on whether you won or lost the bet, and receive an updated balance."));


            Console.Clear();
            CentreText(intro, y); y++;
            CentreText(underline, y); y += 2;
            CentreText(instructions, y); y += instructions.Count + 2;
            CreateBox(100, 20, 25, y, ConsoleColor.White); y += 2;
            Console.SetCursorPosition(30, y); y += 2;
            Console.WriteLine("Doubles:      You win DOUBLE your bet. For example, if you bet $10, you get $20 back.");
            Console.SetCursorPosition(30, y); y += 2;
            Console.WriteLine("Not Doubles:  You win HALF your bet. For example, if you bet $10, you get $5 back.");
            Console.SetCursorPosition(30, y); y += 2;
            Console.WriteLine("Even Sum:     You win your bet. For example, if you bet $10, you get $10 back.");
            Console.SetCursorPosition(30, y); y += 2;
            Console.WriteLine("Odd Sum:      You win your bet. For example, if you bet $10, you get $10 back.");
            Console.SetCursorPosition(30, y); y += 2;
            Console.WriteLine("Snake Eyes:   You win TEN TIMES your bet. For example, if you bet $10 you get $100 back.");
            Console.SetCursorPosition(30, y); y += 2;
            Console.WriteLine("Sum of 7:     You win DOUBLE your bet. For example, if you bet $10 you get $20 back.");
            Console.SetCursorPosition(30, y); y += 3;
            Console.WriteLine("Sum of 3:     You win FOUR TIMES your bet. For example, if you bet $10 you get $40 back.");
            Console.SetCursorPosition(30, y); y++;
            Console.WriteLine("Please note: if you guess correctly, you keep the money you bet along with the money you won.");
            Console.SetCursorPosition(30, y); y += 4;
            Console.WriteLine("If you correctly guessed 'Doubles' and bet $10 and had $100 in cash, you'll end up with $120.");
            CentreText(leave, y);
            Console.ReadLine();
        }
    }
}