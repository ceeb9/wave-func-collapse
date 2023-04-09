using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace randomgen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            int size = 50;

            //create the connection rules
            List<int> zero = new List<int>() {0,1};
            List<int> one = new List<int>() {0,1,2};
            List<int> two = new List<int>() {1,2,3};
            List<int> three = new List<int>() {2,3,4};
            List<int> four = new List<int>() {3,4};
            List<List<int>> connectionRules = new List<List<int>>() {zero, one, two, three, four};
            TileTypes.init(connectionRules);

            //initialize a new grid of tiles
            TileLogic tl = new TileLogic();
            tl.initTiles(new IntVector2(size, size));
            Render.renderAll(tl.tiles);

            while(true)
            {
                tl.updateTiles();
                Render.renderAll(tl.tiles);
            }
            
            
        }
    }
}


