using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<InventoryCell> _inventoryCells = new();

    public Inventory(List<InventoryCell> inventoryCells, int maxSize)
    {
        _inventoryCells = inventoryCells;
        MaxSize = maxSize;
    }

    public int CurrentSize => _inventoryCells.Count;

    public int MaxSize { get; private set; }

    public void Add(Item item)
    {
        foreach (InventoryCell cell in _inventoryCells)
            if (cell.IsOccupied == true && cell.ReadOnlyItem.ID != item.ID)
                return;
            else
                cell.AddItem(item);
    }

    public Item GetItemBy(int id)
    {
        foreach (InventoryCell cell in _inventoryCells)
            if (cell.ReadOnlyItem.ID == id)
                return cell.GetItem();

        return null;
    }

    public void ShowAllItem()
    {
        foreach (InventoryCell cell in _inventoryCells)
            Debug.Log("Item ID: " + cell.ReadOnlyItem.ID 
                + ", In Stack Now: " + cell.ReadOnlyItem.Stack 
                + ", Max Stack: " + cell.ReadOnlyItem.MaxStack);
    }
}