namespace InventoryLoggerSystem
{
    public record InventoryItem(int Id, string Name, int Quantity) : IInventoryEntity;
}
