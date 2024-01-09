using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Slots;
using UnityEngine;
using UnityEngine.UI;

public class SubSlot : MonoBehaviour
{
    private Image subSlotIcon;
    private SubSlotColorType _subSlotColorType;
    private SubSlotShapeType _subSlotShapeType;
    private SubSlotData _subSlotData;
    private void Awake()
    {
        subSlotIcon = GetComponent<Image>();
    }
    
    public void Initialize(SubSlotData subSlotData)
    {
        if (subSlotData == null)
        {
            //gameObject.SetActive(false);
            subSlotIcon.DOFade(0, 0);
            return;
        }
        _subSlotData = subSlotData;
        SetupView();
    }

    private void SetupView()
    {
        subSlotIcon.sprite = _subSlotData.GetSubSlotShapeSprite(SubSlotShapeType.Y_X_HALF);
    }

    public void SetupView(SubSlotShapeType subSlotShapeType)
    {
        subSlotIcon.sprite = _subSlotData.GetSubSlotShapeSprite(subSlotShapeType);
        subSlotIcon.SetNativeSize();
    }
}

public enum SubSlotColorType
{
    NONE=0,
    GREEN = 1,
    BLUE = 2,
    ORANGE = 3,
    YELLOW = 4,
    RED = 5,
    PINK = 6,
    PURPLE = 7,
    DARK_PINK = 8,
    DARK_BLUE = 9,
    LIGHT_GREEN = 10,
}

public enum SubSlotShapeType
{
    NONE = 0,
    FULL = 1,
    Y_HALF = 2,
    Y_X_HALF = 3,
}