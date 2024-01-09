using System;
using Slots;
using UnityEngine;

namespace DefaultNamespace
{
    public class NewSlotTileController : MonoBehaviour
    {
        [SerializeField] private Slot slotPrefab;
        private Slot _current;

        public void ClearCurrent() => _current = null;
        
        public void Generate(SlotsConfig slotsConfig)
        {
            if (_current == null)
            {
                Slot generated = Instantiate(slotPrefab, transform);
                generated.Initialize(slotsConfig, Vector2.zero);
                _current = generated;
            } 
        }
    }
}