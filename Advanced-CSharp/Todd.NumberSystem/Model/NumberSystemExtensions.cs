namespace Todd.NumberSystem.Model
{
    public static class NumberSystemExtensions
    {
        public static void Guard(this string source, string allowedCharachters, NumberBase numberBase)
        {
            foreach (var ch in source)
            {
                if (!allowedCharachters.Contains(ch))
                {
                    throw new InvalidOperationException($"{source} is invalid {numberBase} format ");
                }
            }
        }

        public static string To<T>(this T source, NumberBase toBase) where T : Base
        {
#if DEBUG
            Console.WriteLine("This will be shown in debug mode only");
#endif
            NumberBase fromBase;

            switch (source)
            {
                case BinraySystem: fromBase = NumberBase.BINARY; break;
                case OctalSystem: fromBase = NumberBase.OCTAL; break;
                case DecimalSystem: fromBase = NumberBase.DECIMAL; break;
                case HexaDecimalSystem: fromBase = NumberBase.HEXADECIAML; break;
                default: fromBase = NumberBase.DECIMAL; break;
            }

            return Convert.ToString(Convert.ToInt32(source.Value, (int)fromBase), (int)toBase);
        }
    }
}