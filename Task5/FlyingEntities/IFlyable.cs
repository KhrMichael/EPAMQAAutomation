namespace Task5.FlyingEntities
{
    /// <summary>
    /// Provides basic methods for flying entities
    /// </summary>
    public interface IFlyable
    {
        /// <summary>
        /// Flight to the given coordinates.
        /// </summary>
        /// <param name="coordinate">Coordinates to which need to fly.</param>
        public void FlyTo(Coordinate coordinate);

        /// <summary>
        /// Returns time of flight to the given coordinates.
        /// </summary>
        /// <param name="destinationCoordinate">Coordinates to which need to fly.</param>
        /// <returns>Time in hours.</returns>
        public double GetFlyTime(Coordinate destinationCoordinate);
    }
}
