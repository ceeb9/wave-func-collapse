using System;

namespace randomgen
{
    public class Render
    {
        public static void renderAll(Tile[,] grid, int highx = 0, int highy = 0)
        {
            Console.SetCursorPosition(0, 0);
            for (var y = 0; y < grid.GetLength(1); y++)
            {
                for (var x = 0; x < grid.GetLength(0); x++)
                {
                    if (grid[x, y].possibleTypes.Count == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(grid[x, y].possibleTypes[0] + " ");
                    }
                    else if(x == highx && y == highy)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(grid[x, y].possibleTypes.Count + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(grid[x, y].possibleTypes.Count + " ");
                    } 
                }
                Console.Write('\n');
            }
        }
    }
}