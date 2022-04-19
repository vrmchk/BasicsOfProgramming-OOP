namespace Lab5Sharp
{
    internal abstract class Line
    {
        public abstract bool IsParallelTo(Line line);
        public abstract bool IsPerpendicularTo(Line line);
        public abstract bool ContainsPoint(Point point);
    }
}