namespace Task5.FlyingEntities
{
    /// <summary>
    /// Provides basic methods for flying entities
    /// </summary>
    public interface IFlyable
    {
        public void FlyTo(Coordinate coordinate);
        public double GetFlyTime(Coordinate destinationCoordinate);
    }
}
