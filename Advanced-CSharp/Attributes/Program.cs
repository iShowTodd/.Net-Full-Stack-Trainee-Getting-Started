using System.Reflection;

namespace Attributes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Update[] updates = {
             new Update (1, "security update"),
             new Update (2, "ui enhancements"),
             new Update (3, "No. of bug fixes update"),
             new Update (4, "security update"),
            };
            UpdateProcessor.Download(updates);
            UpdateProcessor.Install(updates);
            UpdateProcessor.DownloadAndInstall(updates);

            List<Player> players = new List<Player>
            {
                new Player
                {
                    Name = "Lionel Messi",
                    BallControl = 9,
                    Dribbling = 18,
                    Passing = 4,
                    Speed = 85,
                    Power = 990
                },
                new Player
                {
                    Name = "Christiano Ronaldo",
                    BallControl = 9,
                    Dribbling = 21,
                    Passing = 4,
                    Speed = 110,
                    Power = 980
                },
                new Player
                {
                    Name = "Naymar Jr",
                    BallControl = 11,
                    Dribbling = 16,
                    Passing = 4,
                    Speed = 85,
                    Power = 1000
                }
            };
            var errors = new List<Error>();
            foreach (var player in players)
            {
                var properties = player.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    var skillAttribute = prop.GetCustomAttribute<SkillAttribute>();
                    if (skillAttribute is not null)
                    {
                        var value = prop.GetValue(player);
                        if (!skillAttribute.IsValid(value))
                        {
                            errors.Add(new Error(prop.Name,
                                $"Invalid value Accepted Range is {skillAttribute.Minimum}-{skillAttribute.Maximum}"));
                        }
                    }
                }
            }
            if (errors.Count > 0)
            {
                foreach (var e in errors)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("players info are valid");
            }
            Console.ReadKey();
        }
    }
}