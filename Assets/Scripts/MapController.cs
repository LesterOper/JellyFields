using Slots;
using UnityEngine;

namespace DefaultNamespace
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private SlotsConfig slotsConfig;
        [SerializeField] private Slot slotPrefab;
        [SerializeField] private MapTile _mapTile;
        private Map _map;
        public void Initialize()
        {
            _map = new Map(_mapTile);
            _map.Generate(transform);
        }
    }

    public class Map
    {
        private MapTile[,] _map;
        private MapGenerator _mapGenerator;
        private MapTile _mapTilePrefab;

        public Map(MapTile mapTile)
        {
            _mapTilePrefab = mapTile;
            _mapGenerator = new MapGenerator();
        }

        public void Generate(Transform parent)
        {
            _map = _mapGenerator.Generate(_mapTilePrefab, parent);
        }
    }
}