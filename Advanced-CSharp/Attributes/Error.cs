namespace Attributes
{
    public class Error
    {
        private string field;
        private string details;

        public Error(string field, string details)
        {
            this.field = field;
            this.details = details;
        }

        public override string ToString()
        {
            return $"{{\"{field}\": \"{details}\"}}";
        }
    }
}