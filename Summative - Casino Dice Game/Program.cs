using Part_6___Loops_Assignment;

namespace Summative___Casino_Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cash = 100, betAmount = 0;
            bool done = false, win = false, lost = false;
            string choice = "";
            Die d1 = new Die(6);
            Die d2 = new Die(6);
            Console.CursorVisible = false;
            Console.SetWindowSize(150, 45);


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
            casinoBets.Add(new string("Option 7: Sum of 3 (5X Bet)"));

            List<string> neutralCasino = new List<string>();
            neutralCasino.Add(new string("The dealer's ready. The dice are waiting."));
            neutralCasino.Add(new string("The air is heavy with chance. Care to tempt fate?"));
            neutralCasino.Add(new string("The dice have no mercy. Shall we begin?"));
            neutralCasino.Add(new string("The Devil watches, amused by your desperation."));

            List <string> losingCasino = new List<string>();
            losingCasino.Add(new string("The dice smell fear. Care to feed them?"));
            losingCasino.Add(new string("You're running out of chips... and chances."));
            losingCasino.Add(new string("Running low? The house loves a desperate player."));
            losingCasino.Add(new string("The last rolls are always the loudest."));

            List<string> winningCasino = new List<string>();
            winningCasino.Add(new string("The dice seem to like you... for now."));
            winningCasino.Add(new string("You're winning... the house hates that."));
            winningCasino.Add(new string("You've cheated fate... or has fate chosen to let you?"));
            winningCasino.Add(new string("The Devil smiles... but not kindly. Fortune favours you -- for now."));

            List <string> guessedCorrectly = new List<string>();
            guessedCorrectly.Add(new string("Hmm... the dice have spared you. The Devil doesn't like that."));
            guessedCorrectly.Add(new string("Luck has chosen you this time. Don't expect it to stay loyal."));
            guessedCorrectly.Add(new string("A small victory, nothing more. The darkness is patient."));
            guessedCorrectly.Add(new string("You've slipped past fate's grasp... but only for a moment."));

            List<string> guessedIncorrectly = new List<string>();
            guessedIncorrectly.Add(new string("Ah... the dice have turned. The Devil smiles."));
            guessedIncorrectly.Add(new string("Luck has abandoned you. The dark grows hungry."));
            guessedIncorrectly.Add(new string("The dice do not lie. You were never meant to win."));
            guessedIncorrectly.Add(new string("One step closer to the inevitable..."));

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
            string afterBet1 = "Very well... the wager is set. Shall we see if luck lights your path,";
            string afterBet2 = "or snuffs it out?";
            string loss1 = "The Devil leans back, smiling. 'Your wallet is empty. Your luck... spent.'";
            string loss2 = "No coins left. No wager to make. No bets left to pray upon.";
            string loss3 = "The shadows laugh softly. You have nothing left to offer.";
            string loss4 = "The house collects. It always does.";
            string loss5 = "Press 'ENTER' to return to the main menu.";

            //---------------------------

            while (!done)
            {
                Console.CursorVisible = false;
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
                Console.CursorVisible = true;
                Console.Write("Enter in your choice here (1 - 3): ");
                choice = Console.ReadLine().Trim();
                while (choice != "1" && choice != "2" && choice != "3")
                {
                    y++;
                    Console.SetCursorPosition(61, y);
                    Console.Write("Invalid Input. Try again: ");
                    choice = Console.ReadLine();
                }
                Console.CursorVisible = false;
                if (choice == "1" && lost == false)
                {
                    while (true)
                    {
                        Console.CursorVisible = false;
                        
                        d1.RollDie();
                        d2.RollDie();
                        y = 4;
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
                        CreateBox(142, 40, 4, 2, casinoColor);
                        if (cash <= 0)
                        {
                            CentreText(loss1, 6, ConsoleColor.Red, 50);
                            Thread.Sleep(500);
                            CentreText(loss2, 9, ConsoleColor.Red, 50);
                            Thread.Sleep(500);
                            CentreText(loss3, 12, ConsoleColor.Red, 50);
                            Thread.Sleep(500);
                            CentreText(loss4, 22, ConsoleColor.Red, 120);
                            Thread.Sleep(1000);
                            CentreText(loss5, 35);
                            lost = true;
                            Console.ReadLine();
                            break;
                        }
                        CustomText(cashText, 143 - cashText.Length, y, ConsoleColor.Green);
                        if (cash == 100)
                        {
                            CustomText(neutralCasino, 8, y, casinoColor, true);
                        }
                        else if (cash < 100)
                        {
                            CustomText(losingCasino, 8, y, casinoColor, true);
                        }
                        else if (cash > 100)
                        {
                            CustomText(winningCasino, 8, y, casinoColor, true);
                        }
                        y += 3;
                        CustomText(enterBet, 8, y, casinoColor); y++;
                        CustomText(betUnderline, 8, y, casinoColor); y += 3;
                        CustomText(casinoBets, 8, y, casinoColor, false); y += 15;
                        CustomText(new string("Enter your choice here (1 - 7): "), 8, y, casinoColor);
                        Console.CursorVisible = true;
                        Console.ForegroundColor = casinoColor;
                        Console.SetCursorPosition(40, y);
                        choice = Console.ReadLine();
                        while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6" && choice != "7")
                        {
                            if (y > 26)
                            {
                                y--;
                                CustomText(new string("                                                                                                                                          |"), 8, y + 1, casinoColor);
                            }
                            y++;
                            Console.ForegroundColor = casinoColor;
                            Console.SetCursorPosition(8, y);
                            Console.Write("Invalid Input. Try again: ");
                            choice = Console.ReadLine();
                        }
                        y += 2;
                        CustomText(new string("Enter your bet here: $"), 8, y, casinoColor);
                        Console.ForegroundColor = casinoColor;
                        Console.SetCursorPosition(30, y);
                        while (!double.TryParse(Console.ReadLine(), out betAmount))
                        {
                            if (y > 29)
                            {
                                y--;
                                CustomText(new string("                                                                                                                                          |"), 8, y + 1, casinoColor);
                            }
                            y++;
                            Console.ForegroundColor = casinoColor;
                            Console.SetCursorPosition(8, y);
                            Console.Write("Invalid Input. Try again: $");
                        }
                        while (betAmount > cash || betAmount <= 0)
                        {
                            if (y > 29)
                            {
                                y--;
                                CustomText(new string("                                                                                                                                          |"), 8, y + 1, casinoColor);
                            }
                            y++;
                            Console.ForegroundColor = casinoColor;
                            Console.SetCursorPosition(8, y);
                            Console.Write("Bet amount can't be placed. Enter a valid number: $");
                            while (!double.TryParse(Console.ReadLine(), out betAmount))
                            {
                                if (y > 29)
                                {
                                    y--;
                                    CustomText(new string("                                                                                                                                          |"), 8, y + 1, casinoColor);
                                }
                                y++;
                                Console.ForegroundColor = casinoColor;
                                Console.SetCursorPosition(8, y);
                                Console.Write("Invalid Input. Try again: $");
                            }
                        }
                        Console.CursorVisible = false;
                        y += 3;
                        Console.ResetColor();
                        Console.SetCursorPosition(120, 4);
                        Console.Write(new string(' ', 23));
                        cash -= betAmount;
                        cashText = $"Your cash: {cash.ToString("C")}";
                        CustomText(cashText, 143 - cashText.Length, 4, ConsoleColor.Green);
                        CustomText(afterBet1, 8, y, casinoColor, 45); y++;
                        CustomText(afterBet2, 8, y, casinoColor, 45);
                        Thread.Sleep(700);
                        CreateBox(33, 8, 95, 16, casinoColor);
                        Thread.Sleep(500);
                        d1.DrawRoll(100, 18, casinoColor, 300);
                        Thread.Sleep(500);
                        d2.DrawRoll(114, 18, casinoColor, 300);
                        win = CheckBet(d1, d2, choice);
                        if (win)
                        {
                            WinningDice(100, 18, 140, d1, d2);
                            Console.SetCursorPosition(120, 4);
                            Console.Write(new string(' ', 23));
                            cash += CalculateMoney(choice, betAmount);
                            cashText = $"Your cash: {cash.ToString("C")}";
                            CustomText(cashText, 143 - cashText.Length, 4, ConsoleColor.Green);
                            CentreText(guessedCorrectly, 36, ConsoleColor.Yellow, 50);
                        }
                        else
                        {
                            LosingDice(100, 18, 500, d1, d2);
                            CentreText(guessedIncorrectly, 36, ConsoleColor.DarkRed, 50);
                        }
                        
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
        public static double CalculateMoney(string choice, double bet)
        {
            if (choice == "1")
            {
                return bet + (bet * 2);
            }
            else if (choice == "2")
            {
                return bet + (bet * 0.5);
            }
            else if (choice == "3")
            {
                return 2 * bet;
            }
            else if (choice == "4")
            {
                return 2 * bet;
            }
            else if (choice == "5")
            {
                return bet + (bet * 10);
            }
            else if (choice == "6")
            {
                return bet + (bet * 2);
            }
            else if (choice == "7")
            {
                return bet + (bet * 5);
            }
            else
            {
                return 0;
            }
        }
        public static void CentreText(string text, int y)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, y);
            Console.WriteLine(text);
        }
        public static void CentreText(string text, int y, ConsoleColor color, int sleep)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, y);
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(sleep);
            }
            Console.ResetColor();
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
        public static void CentreText(List<string> text, int y, ConsoleColor color, int sleep)
        {
            Random generator = new Random();
            int x = generator.Next(1, text.Count);
            Console.SetCursorPosition((Console.WindowWidth - text[x].Length) / 2, y);
            Console.ForegroundColor = color;
            foreach (char c in text[x])
            {
                Console.Write(c);
                Thread.Sleep(sleep);
            }
            Console.ResetColor();
        }
        public static bool CheckBet(Die d1, Die d2, string choice)
        {
            if (choice == "1" && d1.Roll == d2.Roll)
            {
                return true;
            }
            else if (choice == "2" && d1.Roll != d2.Roll)
            {
                return true;
            }
            else if (choice == "3" && (d1.Roll + d2.Roll) % 2 == 0)
            {
                return true;
            }
            else if (choice == "4" && (d1.Roll + d2.Roll) % 2 != 0)
            {
                return true;
            }
            else if (choice == "5" && d1.Roll + d2.Roll == 2)
            {
                return true;
            }
            else if (choice == "6" && d1.Roll + d2.Roll == 7)
            {
                return true;
            }
            else if (choice == "7" && d1.Roll + d2.Roll == 3)
            {
                return true;
            }
            else
            {
                return false;
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
        public static void CustomText(string text, int x, int y, ConsoleColor color, int sleep)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(sleep);
            }
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
        public static void LosingDice(int x, int y, int sleep, Die d1, Die d2)
        {
            Thread.Sleep(1000);
            d1.DrawRoll(x, y, ConsoleColor.DarkMagenta, 0);
            d2.DrawRoll(x + 14, y, ConsoleColor.DarkMagenta, 0);
            Thread.Sleep(1000);
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("                        ");
                y++;
                Thread.Sleep(sleep);
            }
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
            instructions.Add(new string("After you bet your money on your predicted outcome, you'll see two die appear on screen and what they landed on."));
            instructions.Add(new string("You'll then be informed on whether you won or lost the bet, and receive an updated balance."));


            Console.Clear();
            CentreText(intro, y); y++;
            CentreText(underline, y); y += 2;
            CentreText(instructions, y); y += instructions.Count + 2;
            CreateBox(100, 21, 26, y, ConsoleColor.White); y += 2;
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
            Console.WriteLine("Sum of 3:     You win FIVE TIMES your bet. For example, if you bet $10 you get $40 back.");
            Console.SetCursorPosition(30, y); y++;
            Console.WriteLine("Please note: if you guess correctly, you keep the money you bet along with the money you won.");
            Console.SetCursorPosition(30, y); y++;
            Console.WriteLine("If you correctly guessed 'Doubles' and bet $10 and had $100 in cash, you'll end up with $120.");
            Console.SetCursorPosition(38, y); y += 4;
            Console.WriteLine("Also, you CANNOT bet $0 or less, or more money than the cash you have on you.");
            CentreText(leave, y);
            Console.ReadLine();
        }
        public static void WinningDice(int x, int y, int sleep, Die d1, Die d2)
        {
            Thread.Sleep(1000);
            for (int i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(x, y);
                if (i % 2 == 0)
                {
                    d1.DrawRoll(x, y, ConsoleColor.Green, 0);
                    d2.DrawRoll(x + 14, y, ConsoleColor.Green, 0);
                }
                else
                {
                    d1.DrawRoll(x, y, ConsoleColor.White, 0);
                    d2.DrawRoll(x + 14, y, ConsoleColor.White, 0);
                }
                    Thread.Sleep(sleep);
            }
        }
    }
}