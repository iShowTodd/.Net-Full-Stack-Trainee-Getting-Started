using Humanizer;

namespace Facebook
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var comments = new List<FBCommnets> {
                new FBCommnets
                {
                    Owner = "Ahmed Arafa",
                    Comment = "I guess Asp.net is the most powerful web framewrok",
                    CreatedAt = DateTime.Now
                }
                , new FBCommnets
                {
                    Owner = "Any Person on Earth",
                    Comment = "I guess Spring Boot is the most powerful web framewrok",
                    CreatedAt = DateTime.Now
                },
            };

            foreach (var comment in comments)
            {
                Console.WriteLine(comment);
            }
        }
    }

    internal class FBCommnets
    {
        public string Owner { set; get; }
        public string Comment { set; get; }
        public DateTime CreatedAt { get; set; }

        // Ive Downloade the Humanizer library from Nuget Manager
        // to install any package
        // dotnet add package <Package Name> --verison <the version of the package>
        public override string ToString() => $"{Owner} says: \n" +
                       $"\"{Comment}\"" +
                       $"\n\t\t\t\t {CreatedAt.Humanize()}";

        //public override string ToString() => $"{Owner} says: \n" +
        //       $"\"{Comment}\"" +
        //       $"\n\t\t\t\t {CreatedAt:yyyy-MM-dd hh:mm}";
    }
}