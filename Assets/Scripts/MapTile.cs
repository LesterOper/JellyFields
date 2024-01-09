using System;
using Slots;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class MapTile : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        private Slot _slot;
        private bool _activeTile;

        public bool ActiveTile => _activeTile;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _slot = GetComponentInChildren<Slot>();
        }

        public void SetTileActiveState(bool activeTile)
        {
            _activeTile = activeTile;
            ShowOrHide();
        }

        public void Initialize(bool available, SlotsConfig slotsConfig)
        {
            if(available) _slot.InitializeEmptySlot();
            else _slot.Initialize(slotsConfig);
        }

        private void ShowOrHide()
        {
            _slot.gameObject.SetActive(_activeTile);
            _canvasGroup.alpha = _activeTile ? 1 : 0;
        }
    }
}