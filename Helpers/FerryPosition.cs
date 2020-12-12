public class FerryPosition{
    public FerryPosition()
    {
        NorthSouthPosition = 0;
        EastWestPosition = 0;
        FerryDirection = Direction.East;
    }
    // North - positive value, south - negative value
    public int NorthSouthPosition { get; set; }
    // East - positive value, west - negative value
    public int EastWestPosition { get; set; }
    public Direction FerryDirection { get; set; }
}