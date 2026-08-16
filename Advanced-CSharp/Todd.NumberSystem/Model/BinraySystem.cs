namespace Todd.NumberSystem.Model
{
    public class BinraySystem : Base
    {
        public BinraySystem(string value)
        {
            value.Guard("01", NumberBase.BINARY);
            this.Value = value;
        }
    }
}