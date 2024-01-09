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
        private bool hasSlot;
        private Vector2 positionInMap;

        public Vector2 PositionInMap => positionInMap;

        public bool HasSlot => hasSlot;

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

        public void Initialize(bool available, SlotsConfig slotsConfig, Vector2 positionInMap)
        {
            this.positionInMap = positionInMap;
            if (available)
            {
                _slot.InitializeEmptySlot();
                _slot = null;
            }
            else _slot.Initialize(slotsConfig, this.positionInMap);

            hasSlot = !available;
        }

        public void Initialize(Slot insertedSlot)
        {
            hasSlot = true;
            _slot = insertedSlot;
            _slot.Initialize(positionInMap);
        }

        private void ShowOrHide()
        {
            _slot.gameObject.SetActive(_activeTile);
            _canvasGroup.alpha = _activeTile ? 1 : 0;
        }
    }
}