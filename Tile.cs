using System;
using System.Collections.Generic;

namespace randomgen
{
    public class TileType
    {
        public List<int> connections;
        public int id;
        public TileType(int Id, List<int> Connections)
        {
            connections = Connections;
            id = Id;
        }
    }

    public static class TileTypes
    {
        public static List<int> allIds = new List<int>();
        public static List<TileType> allTypes = new List<TileType>();
        public static void init(List<List<int>> connectionRules)
        {
            for (var i = 0; i < connectionRules.Count; i++)
            {
                allIds.Add(i);
            }

            for (var i = 0; i < connectionRules.Count; i++)
            {
                allTypes.Add(new TileType(i, connectionRules[i]));
            }
        }
    }

    public class Tile
    {
        public IntVector2 pos = new IntVector2(0, 0);
        public List<Tile> nearbyTiles = new List<Tile>();
        public List<int> possibleTypes = new List<int>();
        public Tile()
        {
            possibleTypes = new List<int>(TileTypes.allIds);
        }
    }
}

