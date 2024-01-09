using System.Collections.Generic;
using Slots;
using UnityEngine;

public class SlotStateNormalizer
{
    private GridSlotContainer _gridSlotContainer;
    public SlotStateNormalizer(GridSlotContainer container)
    {
        _gridSlotContainer = container;
    }
    public void NormalizeSlot(ref List<Transform> rows)
    {
        if (_gridSlotContainer.SubSlotsCount == 1)
        {
            SingleSubSlot();
            Object.Destroy(rows[1].gameObject);
            rows.RemoveAt(1);
            return;
        }

        if (_gridSlotContainer.SubSlotsCount == 2)
        {
            _gridSlotContainer.SubSlots[0,0].SetupView(SubSlotShapeType.Y_HALF);
            _gridSlotContainer.SubSlots[1,0].SetupView(SubSlotShapeType.Y_HALF);
            _gridSlotContainer.NormalizeCellSizeOfGridLayoutGroup(new Vector2(100, 47));

            return;
        }

        if (_gridSlotContainer.SubSlotsCount == 3)
        {
            _gridSlotContainer.SubSlots[1,0].SetupView(SubSlotShapeType.Y_HALF);
            _gridSlotContainer.NormalizeCellSizeOfGridLayoutGroup(new Vector2(100, 47));
        }
    }

    private void SingleSubSlot()
    {
        _gridSlotContainer.SubSlots[0,0].SetupView(SubSlotShapeType.FULL);
        _gridSlotContainer.NormalizeCellSizeOfGridLayoutGroup(new Vector2(95, 95));
    }
}