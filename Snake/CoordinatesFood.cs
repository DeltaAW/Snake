namespace Snake
{
    public class CoordinatesFood
    {
        private Random r = new();

        // координаты поинтов
        public sbyte X { get; }
        public sbyte Y { get; }

        // предел координат для X и Y
        private byte _maxValueX { get; set; }
        private byte _maxValueY { get; set; }

        public CoordinatesFood(byte maxValueX, byte maxValueY)
        {
            _maxValueX = maxValueX;
            _maxValueY = maxValueY;

            // рандоиные координаты для поинтов
            X = (sbyte)r.Next(1, _maxValueX - 1);
            Y = (sbyte)r.Next(1, _maxValueY - 1);
        }
    }
}
