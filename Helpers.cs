using System;
using System.Collections.Generic;
using System.Linq;

namespace randomgen
{
    public class IntVector2
    {
        public int x;
        public int y;
        public IntVector2(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }

    /*public class Helpers
    {
        public static float priorityCalc(Tile tile)
        {
            float pc = (float)possibleConnections(tile, true).Length;
            
            return pc;
        }

        public static int[] possibleConnections(Tile tile, bool weighted)
        {
            //find the intersection of possible connections of surrounding tiles to find the set of possible connections
            List<int> pc = TileTypes.allIds.ToList();
            
            foreach (var nearbyTile in tile.nearbyTiles)
            {
                if (nearbyTile.revealedType != null)
                {
                    pc = pc.Intersect(nearbyTile.revealedType.connections).ToList();
                }
            }

            List<int> wpc = pc;
            if (weighted)
            {
                //loop through each nearby tile
                foreach (var nearbyTile in tile.nearbyTiles)
                {
                    if (nearbyTile.revealedType != null)
                    {
                        //loop through each nearby tile's possible connections for their type
                        foreach (var connection in nearbyTile.revealedType.connections)
                        {
                            //if it's a valid connection, add it to the list of weighted connection
                            if (pc.Contains(connection))
                            {
                                wpc.Add(connection);
                            }
                        }
                    }
                }
                return wpc.ToArray();
            }
            else
            {
                return pc.ToArray(); 
            }
        }

        public static TileType idToTile(int id)
        {
            return TileTypes.allTypes[id];
        }

        public static void statMessage(int checklistCount, int completedTiles, int ms, int cursX, int cursY)
        {
            //clear the two lines we are going to write to
            Console.SetCursorPosition(cursX, cursY);
            Console.SetCursorPosition(cursX, cursY);
            Console.WriteLine(new String(' ', Console.BufferWidth));
            Console.WriteLine(new String(' ', Console.BufferWidth));
            Console.SetCursorPosition(cursX, cursY);
            Console.SetCursorPosition(cursX, cursY);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Generated {0} tiles in {1}ms. {2} tiles per second. ", completedTiles, ms, Math.Round(1000 * ((float)completedTiles / (float)(ms))));
            Console.WriteLine("Checklist length: {0}", checklistCount);
        }
    }*/
}
