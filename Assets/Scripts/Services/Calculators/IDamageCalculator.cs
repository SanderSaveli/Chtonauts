public interface IDamageCalculator: IService
{
    public int getDamage(TileType tileType);

    public void increaseModificator(TileType tileType, int damageIncrease);
    public void setModificator(TileType tileType, int damageIncrease);

    public void setModificatorForAll(int damageIncrease);
    public void increaseModificatorForAll(int damageIncrease);
}
