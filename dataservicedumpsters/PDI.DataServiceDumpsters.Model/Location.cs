namespace PDI.DataServiceDumpsters.Model
{
    public struct Location
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Location(double x, double y)
        {
            (this.X, this.Y) = (x, y);
        }
    }
}
