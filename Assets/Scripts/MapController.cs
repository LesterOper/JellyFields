using System;
using System.Collections.Generic;
using Slots;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private SlotsConfig slotsConfig;
        [SerializeField] private MapTile _mapTile;
        [SerializeField] private NewSlotsGenerator _newSlotsGenerator;
        private Map _map;

        private void OnEnable()
        {
            EventsInvoker.StartListening(EventsKeys.MERGE, Merge);
        }

        private void OnDisable()
        {
            EventsInvoker.StopListening(EventsKeys.MERGE, Merge);
        }

        private void Merge(Dictionary<string, object> args)
        {
            Vector2 position = (Vector2)args[EventsKeys.MERGE];
            _map.MapProperty = Merger.Merge(_map.MapProperty, position);
            _newSlotsGenerator.GenerateNewSlot();
        }

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

        public MapTile[,] MapProperty
        {
            get { return _map; }
            set => _map = value;
        }

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
                    Vector2 pos = new Vector2(i, j);
                    bool available = Random.Range(0, 2) == 1;

                    if (available)
                    {
                        if(randAvailableTiles <=0) _map[i,j].Initialize(false, slotsConfig, pos);
                        else
                        {
                            _map[i, j].Initialize(true, slotsConfig, pos);
                            randAvailableTiles--;
                        }
                        continue;
                    }
                    
                    _map[i,j].Initialize(false, slotsConfig, pos);
                }
            }
        }
    }
}