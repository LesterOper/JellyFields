using System;
using System.Collections;
using System.Collections.Generic;
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
        _subSlotData = subSlotData;
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