using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameEnter : MonoBehaviour
    {
        [SerializeField] private MapController _mapController;

        private void Start()
        {
            if (_mapController == null) _mapController = FindObjectOfType<MapController>();
            
            _mapController.Initialize();
        }
    }
}