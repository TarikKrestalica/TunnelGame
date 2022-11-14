using System;

namespace TunnelGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Setup: Create the tunnel, the player, and put the player at the starting position
            int SIZE = 50;
            char[] tunnel = CreateTunnel(SIZE);
            char player = '$';
            int playerIndex = 4;
            tunnel[playerIndex] = player;

            // Play the Game: Until the player reaches either the start or end of the tunnel
            while (true)
            {
                PrintTunnel(tunnel);

                // Check keyboard input
                var input = Console.ReadKey();
                // Left: Avoid the start of the tunnel
                if (input.Key == ConsoleKey.LeftArrow)
                    if (playerIndex > 1)
                    {
                        playerIndex--;
                        MoveLeft(tunnel, player, playerIndex);
                    }

                // Right: Avoid the end of the tunnel
                if (input.Key == ConsoleKey.RightArrow)
                    if (playerIndex < SIZE - 2)
                    {
                        playerIndex++;
                        MoveRight(tunnel, player, playerIndex);
                    }

                // Escape
                if (input.Key == ConsoleKey.Escape)
                    break;

                Console.Clear();
            }

        }

        // Make the tunnel of the user's size
        public static char[] CreateTunnel(int size)
        {
            char[] array = new char[size];
            // Idea: start and end positions contain hashes, otherwise fill with empty spaces
            for (int i = 0; i < size; i++)
            {
                if (i > 0 && i < size - 1)
                    array[i] = ' ';
                else
                    array[i] = '#';
            }

            return array;
                 
        }
        
        // Print the Tunnel State
        public static void PrintTunnel(char[] array)
        {
            // Place dividers except in the first and last positions
            for(int i = 0; i < array.Length; i++)
            {
                if (i < array.Length - 1)
                    Console.Write(array[i] + "|");
                else
                    Console.Write(array[i]);
            }
                
        }

        // Move the Character Left
        public static void MoveLeft(char[] array, char aPlayer, int position)
        {
            // Set the rightmost position as empty, then add the player to the left
            array[position + 1] = ' ';
            array[position] = aPlayer;
        }
        // Move the Character Right
        public static void MoveRight(char[] array, char aPlayer, int position)
        {
            // Set the leftmost position as empty, add the player to the right
            array[position - 1] = ' ';
            array[position] = aPlayer;
        }
    }
}
