using Slots;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private SlotsConfig slotsConfig;
        [SerializeField] private Slot slotPrefab;
        [SerializeField] private MapTile _mapTile;
        private Map _map;
        public void Initialize()
        {
            _map = new Map(_mapTile, gridLayoutGroup);
            _map.GenerateMap(transform);
            _map.GenerateMapTiles(slotsConfig);
        }
    }

    public class Map
    {
        private MapTile[,] _map;
        private MapGenerator _mapGenerator;
        private MapTile _mapTilePrefab;

        public Map(MapTile mapTile, GridLayoutGroup gridLayoutGroup)
        {
            _mapTilePrefab = mapTile;
            _mapGenerator = new MapGenerator(gridLayoutGroup);
        }

        public void GenerateMap(Transform parent) => _map = _mapGenerator.Generate(_mapTilePrefab, parent);

        public void GenerateMapTiles(SlotsConfig slotsConfig)
        {
            var minAvailableTiles = _mapGenerator.CurrentLevelPattern.MinAvailableSlots;
            var maxAvailableTiles = _mapGenerator.CurrentLevelPattern.MaxAvailableSlots;
            int randAvailableTiles = Random.Range(minAvailableTiles, maxAvailableTiles + 1);
            int rowCount = _map.GetUpperBound(0) + 1;
            int columnCount = _map.GetUpperBound(1) + 1;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if(!_map[i,j].ActiveTile) continue;
                    bool available = Random.Range(0, 2) == 1;

                    if (available)
                    {
                        if(randAvailableTiles <=0) _map[i,j].Initialize(false, slotsConfig);
                        else
                        {
                            _map[i, j].Initialize(true, slotsConfig);
                            randAvailableTiles--;
                        }
                        continue;
                    }
                    
                    _map[i,j].Initialize(false, slotsConfig);
                }
            }
        }
    }
}