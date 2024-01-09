using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Slots
{
    [CreateAssetMenu(menuName = nameof(SlotsConfig), fileName = nameof(SlotsConfig))]
    public class SlotsConfig : ScriptableObject
    {
        [SerializeField]private List<SubSlotData> SubSlotDatas;

        public SubSlotData GetSubSlotData(SubSlotColorType subSlotColorType) =>
            SubSlotDatas.FirstOrDefault(slot => slot.SubSlotColorType == subSlotColorType);
    }

    [Serializable]
    public class SubSlotData
    {
        public SubSlotColorType SubSlotColorType;
        public List<SubSlotShapeData> SubSlotShapeDatas;

        public Sprite GetSubSlotShapeSprite(SubSlotShapeType subSlotShapeType) => SubSlotShapeDatas
            .FirstOrDefault(slot => slot.SubSlotShapeType == subSlotShapeType)?.Sprite;


    }

    [Serializable]
    public class SubSlotShapeData
    {
        public SubSlotShapeType SubSlotShapeType;
        public Sprite Sprite;
    }
}