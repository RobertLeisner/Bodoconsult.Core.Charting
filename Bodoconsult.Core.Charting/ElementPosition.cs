namespace Bodoconsult.Core.Charting
{
    public class ElementPosition
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }

        public float Height { get; set; }


        public ElementPosition()
        {

        }

        public ElementPosition(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

    }
}