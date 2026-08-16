namespace Todd.NumberSystem
{
    public static class NumberSystemExtensions
    {
        public static void Guard(this string source, string allowedCharachters, NumberBase numberBase)
        {
            foreach (var char in source){
                if (!allowedCharachters.Contains(char))
                {
                    throw new InvalidOperationException($"{source} is invalid {numberBase} format ");
                }
            }
        }

        public static string To<T>(this T source, NumberBase numberBase) where T : Base
        {
            NumberBase frombase;
            switch (source)
            {
                case BinraySystem: frombase = NumberBase.BINARY; break;
                case DecimalSystem: frombase = NumberBase.DECIMAL; break;
                case HexaDecimalSystem: frombase = NumberBase.HEXADECIAML; break;
                case OctalSystem: frombase = NumberBase.OCTAL; break;
                default: frombase = NumberBase.DECIMAL; break;
            }
            return Convert.ToString(Convert.ToInt32(source.value), (int)frombase),(int)toBase);
        }
    }
}