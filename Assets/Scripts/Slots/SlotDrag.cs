using System;
using System.Collections.Generic;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Slots
{
    public class SlotDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IPointerUpHandler
    {
        private NewSlotTileController _slotTileController;
        private Slot thisSlot;
        private Image slotGraphicComponent;
        private RectTransform _rectTransform;
        private Transform famParent;
        private Transform firstParent;
        private Vector3 mOffset;

        private void Awake()
        {
            _slotTileController = GetComponentInParent<NewSlotTileController>();
            _rectTransform = GetComponent<RectTransform>();
            slotGraphicComponent = GetComponent<Image>();
            famParent = transform.parent.parent.parent;
            firstParent = transform.parent;
        }

        public void Initialize(Slot slot) => thisSlot = slot;

        public void ChangeComponentState(bool active)
        {
            enabled = active;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            if (enabled)
            {
                transform.SetParent(famParent);
                mOffset = gameObject.transform.position - GetMouseWorldPos();
                slotGraphicComponent.raycastTarget = false;
            }
        }

        private Vector3 GetMouseWorldPos()
        {
            Vector3 mouse = Input.mousePosition;
            mouse.z = 0;
            return Camera.main.ScreenToWorldPoint(mouse);
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
        }
        
        

        public void OnDrag(PointerEventData eventData)
        {
            if (enabled)
            {
                transform.position = GetMouseWorldPos() + mOffset;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (enabled)
            {
                if (eventData.pointerEnter.TryGetComponent(out MapTile mapTile))
                {
                    if (mapTile.ActiveTile)
                    {
                        if (!mapTile.HasSlot)
                        {
                            transform.SetParent(mapTile.transform);
                            _rectTransform.DOAnchorPos(Vector2.zero, 0.2f);
                            ChangeComponentState(false);
                            mapTile.Initialize(thisSlot);
                            _slotTileController.ClearCurrent();
                            EventsInvoker.TriggerEvent(EventsKeys.MERGE, new Dictionary<string, object>()
                            {
                                {EventsKeys.MERGE, mapTile.PositionInMap}
                            });
                            return;
                        }
                    }
                }

                _rectTransform.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.InSine);
                transform.SetParent(firstParent);
                slotGraphicComponent.raycastTarget = true;
            }
        }
    }
}