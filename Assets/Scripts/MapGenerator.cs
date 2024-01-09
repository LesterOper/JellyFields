using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MapGenerator
    {
        private GridLayoutGroup _gridLayoutGroup;
        private LevelPatternsXmlSerializer _levelPatternsXmlSerializer;
        private LevelPattern currentLevelPattern;

        public LevelPattern CurrentLevelPattern => currentLevelPattern;

        public MapGenerator(GridLayoutGroup gridLayoutGroup)
        {
            _gridLayoutGroup = gridLayoutGroup;
            _levelPatternsXmlSerializer = new LevelPatternsXmlSerializer();
            _levelPatternsXmlSerializer.ParseXml();
        }
        public MapTile[,] Generate( MapTile mapTilePrefab, Transform parent)
        {
            currentLevelPattern = _levelPatternsXmlSerializer.GetCurrentLevelPattern(8);
            int[,] mapPattern = currentLevelPattern.GetParsedToIntMapPattern();
            int rowCount = mapPattern.GetUpperBound(0) + 1;
            int columnCount = mapPattern.GetUpperBound(1) + 1;
            MapTile[,] mapTiles = new MapTile[rowCount,columnCount];
            _gridLayoutGroup.constraintCount = columnCount;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    MapTile tile = Object.Instantiate(mapTilePrefab, parent);
                    tile.SetTileActiveState(mapPattern[i, j] == 1);
                    mapTiles[i, j] = tile;
                }
            }
            return mapTiles;
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