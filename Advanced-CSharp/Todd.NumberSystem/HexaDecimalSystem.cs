namespace Todd.NumberSystem
{
    public class HexaDecimalSystem : Base
    {
        public HexaDecimalSystem(string value)
        {
            value.Guard("ABCDEF0123456789", NumberBase.HEXADECIAML);
            this.value = value
        }
    }
}