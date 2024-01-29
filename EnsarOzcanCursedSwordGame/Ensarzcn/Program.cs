using System;

class Program
{
    static int playerX = 2;
    static int playerY = 2;
    static int villagerX = 3;
    static int villagerY = 1;
    static int clueX = 1; // Ipucunun konumu
    static int clueY = 1; // Ipucunun konumu
    static int swordX = 3; // Hans'ın Kılıcı'nın konumu
    static int swordY = 3; // Hans'ın Kılıcı'nın konumu
    static int roomSize = 5;
    static bool hasSword = false;
    static bool hasRiddleClue = false;
    static bool hasAnswer = false;

    static void Main()
    {
        Console.WriteLine("Welcome to the Cursed Sword Game!");
        Console.WriteLine("You are inside a room. Look around and find Hans's Sword.");
        Console.WriteLine("Use 'w' to move north, 'a' to move west, 's' to move south, 'd' to move east.");
        Console.WriteLine("Type 'exit' to quit the game.");
        Console.WriteLine("Type 'help' to get help.");

        while (true)
        {
            Console.WriteLine("You are currently at position: (" + playerX + ", " + playerY + ")");

            // Wild Villager'ı sadece ipucunu almadan önce gösterme
            if (hasRiddleClue)
            {
                Console.WriteLine("Wild Villager is currently in the vicinity. You can talk to him. But you need to first find the mistery item !");
            }

            // NPC'nin konumu ve riddle'ı
            if (playerX == villagerX && playerY == villagerY && hasSword && hasRiddleClue)
            {
                Console.WriteLine("You found the Wild Villager, he has a riddle for you !");
                Console.WriteLine("Riddle: What comes once in a minute, twice in a moment, but never in a thousand years?");
                Console.WriteLine("a) The letter 'M'");
                Console.WriteLine("b) Time");
                Console.WriteLine("c) Breath");
                Console.WriteLine("d) Silence");
                Console.WriteLine("e) Space");

                // Player has two chances to answer
                for (int chances = 0; chances < 2; chances++)
                {
                    Console.Write("Your answer (a, b, c, d, e): ");
                    string playerAnswer = Console.ReadLine().ToLower();

                    // Check if the answer is correct
                    if (playerAnswer == "a")
                    {
                        Console.WriteLine("Congratulations! You gave the correct answer!");
                        Console.WriteLine("You WIN!");
                        hasAnswer = true;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Wrong answer. Try again!");
                    }
                }

                // Player couldn't answer correctly in two tries
                Console.WriteLine("Sorry, you couldn't answer correctly in two tries.");
                Console.WriteLine("The Wild Villager attacks you. GAME OVER!");
                return;
            }

            // Ipucu konumu
            if (playerX == clueX && playerY == clueY && !hasRiddleClue)
            {
                Console.WriteLine("You found a clue! 'Look to the skies where the sun sets, and you'll find your answer.'");
                hasRiddleClue = true;
            }

            // Hans's Sword konumu
            if (playerX == swordX && playerY == swordY)
            {
                if (!hasSword)
                {
                    Console.WriteLine("You found Hans's Sword!");
                    hasSword = true;
                }
                else
                {
                    Console.WriteLine("You already have Hans's Sword.");
                }
            }

            Console.Write("Your move: ");
            string move = Console.ReadLine().ToLower();

            if (move == "exit")
            {
                Console.WriteLine("Exiting the game. Goodbye!");
                break;
            }
            else if (move == "help")
            {
                DisplayHelp();
            }
            else
            {
                MovePlayer(move);
            }
        }
    }

    static void MovePlayer(string direction)
    {
        switch (direction)
        {
            case "w":
                if (playerY > 0)
                {
                    playerY--;
                }
                else
                {
                    Console.WriteLine("You've reached the northern edge of the room. Cannot move further north.");
                }
                break;
            case "a":
                if (playerX > 0)
                {
                    playerX--;
                }
                else
                {
                    Console.WriteLine("You've reached the western edge of the room. Cannot move further west.");
                }
                break;
            case "s":
                if (playerY < roomSize - 1)
                {
                    playerY++;
                }
                else
                {
                    Console.WriteLine("You've reached the southern edge of the room. Cannot move further south.");
                }
                break;
            case "d":
                if (playerX < roomSize - 1)
                {
                    playerX++;
                }
                else
                {
                    Console.WriteLine("You've reached the eastern edge of the room. Cannot move further east.");
                }
                break;
            default:
                Console.WriteLine("Invalid move. Use 'w', 'a', 's', 'd' to move, 'help' for assistance, or type 'exit' to quit.");
                break;
        }
    }

    static void DisplayHelp()
    {
        Console.WriteLine("===== Help =====");
        Console.WriteLine("Current Position: (" + playerX + ", " + playerY + ")");
        Console.WriteLine("Wild Villager's Position: (" + villagerX + ", " + villagerY + ")");
        Console.WriteLine("Hans's Sword's Position: (" + swordX + ", " + swordY + ")");
        Console.WriteLine("Riddle Clue's Position: (" + clueX + ", " + clueY + ")");
        Console.WriteLine("===== End of Help =====");
    }
}


