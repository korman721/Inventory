using UnityEngine;

public class InventoryCell
{
    private Item _item;

    public InventoryCell() => _item = null;

    public InventoryCell(Item item) => _item = item;

    public IReadOnlyItem ReadOnlyItem => _item;

    public bool IsOccupied => _item != null;

    public bool TryAddItem(Item item)
    {
        if (_item.ID == item.ID)
        {
            if (_item.TryAddToStack(item.Stack))
            {
                Debug.Log("Add To Stack Complete");
                return true;
            }
            else
            {
                Debug.Log("Add To Stack Not Work");
                return false;
            }
        }

        _item = item;
        return true;
    }

    public Item GetItem()
    {
        Item itemToReturn = _item;
        _item = null;
        return itemToReturn;
    }
}
