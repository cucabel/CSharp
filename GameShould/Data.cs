using ToyRobot;

namespace ToyRobotTests
{
    public static class Data
    {
        public static int validRow() { return (int)Parameters.MinHeight; }
        public static int validCol() { return (int)Parameters.MinWidth; }
        public static int invalidRow() { return (int)Parameters.MaxHeight + (int)Parameters.UnitSpace; }
        public static string validDirection() { return "NORTH"; }
        public static string invalidDirection() { return "CENTER"; }
        public static string validPlaceRobotStringCommand()
        {
            return StringCommand.PlaceRobot + " " + validRow().ToString() + "," + validCol().ToString() + "," + validDirection();
        }
        public static string validPlaceWallStringCommand()
        {
            return StringCommand.PlaceWall + " " + validRow().ToString() + "," + validCol().ToString();
        }
        public static Coordinate bottomLeftCoordinate() { return new Coordinate((int)Parameters.MinWidth, (int)Parameters.MinHeight); }
        public static Coordinate bottomRightCoordinate() { return new Coordinate((int)Parameters.MaxWidth, (int)Parameters.MinHeight); }
        public static Coordinate topLeftCoordinate() { return new Coordinate((int)Parameters.MinWidth, (int)Parameters.MaxHeight); }
        public static Coordinate topRightCoordinate() { return new Coordinate((int)Parameters.MaxWidth, (int)Parameters.MaxHeight); }
        public static ICardinal northCardinal() { return new North(); }
        public static ICardinal eastCardinal() { return new East(); }
        public static ICardinal southCardinal() { return new South(); }
        public static ICardinal westCardinal() { return new West(); }
    }
}
