using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MapGenerator
    {
        private LevelPatternsXmlSerializer _levelPatternsXmlSerializer;

        public MapGenerator()
        {
            _levelPatternsXmlSerializer = new LevelPatternsXmlSerializer();
            _levelPatternsXmlSerializer.ParseXml();
        }
        public MapTile[,] Generate( MapTile mapTilePrefab, Transform parent)
        {
            int[,] mapPattern = _levelPatternsXmlSerializer.ParseToIntMap(5);
            MapTile[,] slots = new MapTile[5,5];
            int rowCount = mapPattern.GetUpperBound(0) + 1;
            int columnCount = mapPattern.GetUpperBound(1) + 1;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    slots[i, j] = mapPattern[i, j] == 1 ? Object.Instantiate(mapTilePrefab, parent) : null;
                }
            }
            return slots;
        }

        private void GenerateRandomMap()
        {
            
        }

        private Slot[,] GenerateFirstLevel()
        {
            return null;
        }
    }
}