using System;
using System.Collections.Generic;
using Slots;
using UnityEngine;

namespace DefaultNamespace
{
    public class NewSlotsGenerator : MonoBehaviour
    {
        [SerializeField] private List<NewSlotTileController> _newSlotTileControllers;
        [SerializeField] private SlotsConfig _slotsConfig;

        private void Start()
        {
            GenerateNewSlot();
        }

        public void GenerateNewSlot()
        {
            _newSlotTileControllers.ForEach(newSlot => newSlot.Generate(_slotsConfig));
        }
    }
}