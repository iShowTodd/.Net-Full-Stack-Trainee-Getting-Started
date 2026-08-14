namespace Attributes
{
    public class Player
    {
        public string Name { get; set; }

        [Skill(nameof(BallControl), 1, 10)]
        public int BallControl { get; set; } // 1 - 10

        [Skill(nameof(Dribbling), 1, 20)]
        public int Dribbling { get; set; } // 1 - 20

        [Skill(nameof(Power), 1, 1000)]
        public int Power { get; set; } // 1 - 1000

        [Skill(nameof(Speed), 1, 100)]
        public int Speed { get; set; } // 1 - 100

        [Skill(nameof(Passing), 1, 4)]
        public int Passing { get; set; } // 1 - 4
    }
}