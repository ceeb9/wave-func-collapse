using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace randomgen
{
    class TileLogic
    {
        //readonly and static objects
        public static readonly int[] xOffset = { -1, 0, 1, -1, 1, -1, 0, 1 };
        public static readonly int[] yOffset = { -1, -1, -1, 0, 0, 1, 1, 1 };
        private Random r = new Random();
        public Tile[,] tiles;
        public List<Tile> tileChecklist = new List<Tile>();

        public void initTiles(IntVector2 size)
        {
            //create a new tile grid
            Tile[,] output = new Tile[size.x, size.y];

            //initialize the tile
            //1. set the position variable of each tile in the grid
            //2. set the references to its nearby tiles
            for (var y = 0; y < size.y; y++)
            {
                for (var x = 0; x < size.x; x++)
                {
                    output[x, y] = new Tile();
                    //1.
                    output[x, y].pos.x = x;
                    output[x, y].pos.y = y;

                }
            }

            //2.
            for (var y = 0; y < size.y; y++)
            {
                for (var x = 0; x < size.x; x++)
                {
                    //add offsets to each tile to check the tiles around them
                    for (int i = 0; i < xOffset.Length; i++)
                    {
                        //check if the tile we are going to add to the nearby list is in the grid
                        if (x + xOffset[i] >= 0 && x + xOffset[i] < size.x && y + yOffset[i] >= 0 && y + yOffset[i] < size.y)
                        {
                            //add the neighbouring tile to the current tile's nearby list
                            output[x, y].nearbyTiles.Add(output[x + xOffset[i], y + yOffset[i]]);
                        }
                    }
                }
            }

            //pick our first tile "randomly"
            int rx = r.Next(0, size.x);
            int ry = r.Next(0, size.y);

            //collapse the sample space to only one possibility
            //int result = output[rx, ry].possibleTypes[r.Next(0, output[rx, ry].possibleTypes.Count)];
            output[rx, ry].possibleTypes.Clear();
            output[rx, ry].possibleTypes.Add(0);


            //remove invalid possibilities
            /*for (int i = 0; i < output[rx, ry].nearbyTiles.Count; i++)
            {
                for (var j = 0; j < output[rx, ry].possibleTypes.Count; j++)
                {
                    output[rx, ry].nearbyTiles[i].possibleTypes = output[rx, ry].nearbyTiles[i].possibleTypes.Intersect(TileTypes.allTypes[output[rx, ry].possibleTypes[j]].connections).ToList();
                }
            }*/
            tiles = output;
        }

        public void updateTiles()
        {
            //remove invalid possibilities
            for (var y = 0; y < tiles.GetLength(1); y++)
            {
                for (var x = 0; x < tiles.GetLength(0); x++)
                {
                    if(tiles[x, y].possibleTypes.Count == 1)
                    {
                        continue;
                    }
                    //dont do this, calc priority for all then pick lowest
                    else if(tiles[x, y].possibleTypes.Count == 2)
                    {
                        //collapse the sample space to only one possibility
                        int result = tiles[x, y].possibleTypes[r.Next(0, tiles[x, y].possibleTypes.Count)];
                        tiles[x, y].possibleTypes.Clear();
                        tiles[x, y].possibleTypes.Add(result);
                        continue;
                    }
                    else if(tiles[x, y].possibleTypes.Count == TileTypes.allIds.Count)
                    {
                        bool an = false;
                        for (int i = 0; i < tiles[x, y].nearbyTiles.Count; i++)
                        {
                            if(tiles[x, y].nearbyTiles[i].possibleTypes.Count != TileTypes.allIds.Count)
                            {
                                an = true;
                                break;
                            }
                        }
                        if(!an)
                        {
                            continue;
                        }
                    }

                    List<int> all = new List<int>(TileTypes.allIds);
                    for (int i = 0; i < tiles[x, y].nearbyTiles.Count; i++)
                    {
                        List<int> cur = new List<int>();
                        for (var j = 0; j < tiles[x, y].nearbyTiles[i].possibleTypes.Count; j++)
                        {
                            //n = n.Intersect(tiles[x, y].nearbyTiles[i].possibleTypes.Intersect(TileTypes.allTypes[tiles[x, y].possibleTypes[j]].connections).ToList()).ToList();
                            cur = cur.Concat(TileTypes.allTypes[tiles[x, y].nearbyTiles[i].possibleTypes[j]].connections).ToList();
                        }
                        cur = cur.Distinct().ToList();
                        all = all.Intersect(cur).ToList();
                    }

                    all = all.Distinct().ToList();

                    Console.Write(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(0, Console.CursorTop-1);
                    foreach (var item in all)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(item + " ");
                    }

                    //Thread.Sleep(50);
                    tiles[x, y].possibleTypes = all;
                    //Render.renderAll(this.tiles, x, y);
                    
                }
            }

        }
    }
}
