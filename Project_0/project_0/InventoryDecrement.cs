namespace project_0
{
    public interface InventoryDecrement
    {
        void PremadeItemGrabed(Item it);
        void ItemWasGrabed(Item item);
        int TooManyGrabed(Item item,int a);         
    }
}