public interface IManaCostCalculator : IService
{
    public int getCost(TileType tileType);

    public void increaseModificator(TileType tileType, int costDecrease);
    public void setModificator(TileType tileType, int costDecrease);

    public void setModificatorForAll(int costDecrease);
    public void increaseModificatorForAll(int costDecrease);
}
