namespace ReturnMultipleValues
{
    public class Location
    {
        public string Name { get; set; }
        public double DistanceInKm { get; set; }

        public override string ToString()
        {
            return $"{Name} ....... {DistanceInKm:F2} km";
        }
    }
}