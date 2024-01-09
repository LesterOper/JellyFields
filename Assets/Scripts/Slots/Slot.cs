using System.Collections.Generic;
using Slots;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Slot : MonoBehaviour
{
    [SerializeField] private SubSlot _subSlotPrefab;
    [SerializeField] private List<Transform> rows;
    private GridSlotContainer _gridSlotContainer;

    private void Awake()
    {
        _gridSlotContainer = new GridSlotContainer(this, _subSlotPrefab);
    }

    public void Initialize(SlotsConfig slotsConfig)
    {
        _gridSlotContainer.Initialize(ref rows, slotsConfig);
    }

    public void InitializeEmptySlot()
    {
        
    }
}


public class GridSlotContainer
{
    private SubSlot _prefab;
    private SubSlot[,] _subSlots;
    private int subSlotsCount;
    private GridLayoutGroup _gridLayoutGroup;
    private SlotStateNormalizer _stateNormalizer;

    public int SubSlotsCount => subSlotsCount;

    public SubSlot[,] SubSlots => _subSlots;

    public GridSlotContainer(Slot slot, SubSlot prefab)
    {
        _gridLayoutGroup = slot.GetComponent<GridLayoutGroup>();
        _prefab = prefab;
        _stateNormalizer = new SlotStateNormalizer(this);
    }

    public void Initialize(ref List<Transform> rows, SlotsConfig slotsConfig)
    {
        subSlotsCount = RandomSubSlotsCountInSlot();
        int rowCount = subSlotsCount > 1 ? 2 : 1;
        int columnCount = subSlotsCount > 2 ? 2 : 1;
        _subSlots = new SubSlot[rowCount, columnCount];
        //_gridLayoutGroup.constraintCount = subSlotsCount > 2 ? 2 : 1;
        int subSlotsBuf = subSlotsCount;
        int rowIndex = 0;
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                if(subSlotsBuf > 0)
                {
                    SubSlot slot = Object.Instantiate(_prefab, rows[i]);
                    slot = SetupSubSlot(slot, slotsConfig);
                    subSlotsBuf--;
                    _subSlots[i, j] = slot;
                }
            }
        }
        
        _stateNormalizer.NormalizeSlot(ref rows);
    }

    private SubSlot SetupSubSlot(SubSlot slot, SlotsConfig slotsConfig)
    {
        SubSlotColorType subSlotColorType = RandomSubSlotType();
        SubSlotData subSlotData = slotsConfig.GetSubSlotData(subSlotColorType);
        slot.Initialize(subSlotData);
        return slot;
    }
    
    private int RandomSubSlotsCountInSlot() => Random.Range(1, 5);
    private SubSlotColorType RandomSubSlotType() => (SubSlotColorType) Random.Range(1, 11);

    public void NormalizeCellSizeOfGridLayoutGroup(Vector2 cellSize)
    {
        _gridLayoutGroup.cellSize = cellSize;
    }
}