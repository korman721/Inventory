public class Item : IReadOnlyItem
{
    public Item(int id, int maxStack)
    {
        ID = id;
        MaxStack = maxStack;
    }

    public int MaxStack { get; private set; }
    public int ID { get; private set; }
    public int Stack { get; private set; }

    public bool TryAddToStack(int count)
    {
        if (Stack + count > MaxStack)
            return false;

        Stack += count;
        return true;
    }
}