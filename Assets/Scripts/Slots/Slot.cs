using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Slot : MonoBehaviour
{
    [SerializeField] private SubSlot _subSlotPrefab;
    private GridSlotContainer _gridSlotContainer;

    private void Awake()
    {
        _gridSlotContainer = new GridSlotContainer(_subSlotPrefab);
    }

    public void Initialize()
    {
        _gridSlotContainer.Initialize();
    }
}


public class GridSlotContainer
{
    private SubSlot _prefab;
    private SubSlot[,] _subSlots;

    public GridSlotContainer(SubSlot prefab)
    {
        _subSlots= new SubSlot[2, 2];
        _prefab = prefab;
    }

    public void Initialize()
    {
        for (int i = 0; i < _subSlots.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < _subSlots.GetUpperBound(1) + 1; j++)
            {
                int rand = Random.Range(0, 2);
                if (rand == 1)
                {
                    
                }
            }
        }
    }
}
