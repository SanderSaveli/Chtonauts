public interface IDurationCalculator: IService
{
    public float getDuration(TileType tileType);

    public void increaseModificator(TileType tileType, float durationDecrease);
    public void setModificator(TileType tileType, float durationDecrease);

    public void setModificatorForAll(float durationDecrease);
    public void increaseModificatorForAll(float durationDecrease);
}
