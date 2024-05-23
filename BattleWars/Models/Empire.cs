
namespace BattleWars.Models
{
    public class Empire
    {
        public Empire(string name, string numberId)
        {
            this.name = name;
            this.numberId = numberId;
        }

        public string name { get; set; }
        public string numberId { get; set; }
        public double life { get; set; } = SetRandomLife();
        public double damage { get; set; } = SetRandomDamage();
        public bool isDead { get; set; } = false;

        private static double SetRandomLife()
        {
            Random random = new Random();
            return random.Next(1000, 2001);
        }

        private static double SetRandomDamage()
        {
            Random randomPercentage = new Random();
            int percentage = randomPercentage.Next(0, 101);

            Random random = new Random();
            int damage = random.Next(100, 501);
            return (damage * percentage) / 100;
        }
    }
}
