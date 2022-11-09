using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5._Dragon_Army___second_variant
{
    internal class Program
    {
        static void Main()
        {
            int numberOfDragons = int.Parse(Console.ReadLine());

            DragonArmy army = new DragonArmy();
            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] args = SplitString(Console.ReadLine());
                string type=args[0];
                Dragon dragon = ParseDragon(args);

                army.AddDragon(type, dragon);


            }
            Console.WriteLine(army);
        }
        private static Dragon ParseDragon(string[] args)
        {
            string name = args[1];
            string damage = args[2];
            string health = args[3];
            string armor = args[4];

            Dragon parsed = new Dragon(name,health, damage, armor);
            return parsed;
        }
        private static string[] SplitString(string toSplit)
        {
            return toSplit.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
    class DragonArmy
    {
        private const string TYPE_FORMAT = "{0}::({1:F2}/{2:F2}/{3:F2})";
        private const string DRAGON_FORMAT = "-{0}";
        private Dictionary<string, Dictionary<string, Dragon>> dragonsByType;
        public DragonArmy()
        {
            dragonsByType = new Dictionary<string, Dictionary<string, Dragon>>();
        }
        public void AddDragon(string type, Dragon dragon)
        {
            if (!this.dragonsByType.ContainsKey(type))
            {
                this.dragonsByType.Add(type, new Dictionary<string, Dragon>());

            }
            Dictionary<string, Dragon> dragonsByName = this.dragonsByType[type];
            string dragonName = dragon.Name;

            dragonsByName[dragonName] = dragon;

        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (KeyValuePair<string, Dictionary<string, Dragon>> kvp in this.dragonsByType)
            {
                string type = kvp.Key;
                Dictionary<string, Dragon> dragonsByName = kvp.Value;
                string formatted = GetTypeFormat(type, dragonsByName);
                result.AppendLine(formatted);
               AddDragons(result, dragonsByName);

            }
            return result.ToString();
        }

        private void AddDragons(StringBuilder result, Dictionary<string, Dragon> dragonsByName)
        {
            foreach (KeyValuePair<string, Dragon> dragonAndName in dragonsByName.OrderBy(x=>x.Key))
            {
                string dragonInfo = dragonAndName.Value.ToString();
               string formatted = string.Format(DRAGON_FORMAT, dragonInfo);
                result.AppendLine(formatted);
            }

            
        }

        private string GetTypeFormat(string type, Dictionary<string, Dragon> dragonsByName)
        {
            double dragonsCount = dragonsByName.Count;
            double averageDamage = GetAverage(dragonsByName, d => d.Damage, dragonsCount);
            double averageHealth = GetAverage(dragonsByName, d => d.Health, dragonsCount);
            double averageArmor = GetAverage(dragonsByName, d => d.Armor, dragonsCount);
            string formatted = string.Format(TYPE_FORMAT, type, averageDamage, averageHealth, averageArmor);
            return formatted;
        }

        private double GetAverage(Dictionary<string, Dragon> dragonsByName, Func<Dragon, int> selector, double dragonsCount)
        {
           return dragonsByName.Sum(d => selector(d.Value)) / dragonsCount;
        }
    }

    class Dragon
    {
        private const string Null = "null";
        private const string TO_STRING_FORMAT = "-{0} -> damage: {1}, health: {2}, armor: {3}";
        private const int DEFAULT_HEALTH = 250;
        private const int DEFAULT_DAMAGE = 45;
        private const int DEFAULT_ARMOR = 10;


        private string name;
        private int health;
        private int damage;
        private int armor;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public int Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public Dragon(string name,string health, string damage, string armor)
        {
            this.name = name;
            this.health = ParseHealth(health);
            this.damage = ParseDamage(damage);
            this.armor = ParseArmor(armor);
        }
        private bool StringIsNullAsText(string value)
        {
            return value == Null;
        }
        private int ParseHealth(string health)
        {
            if (this.StringIsNullAsText(health))
            {
                return DEFAULT_HEALTH;
            }
            return int.Parse(health);
        }
        private int ParseDamage(string damage)
        {
            if (this.StringIsNullAsText(damage))
            {
                return DEFAULT_DAMAGE;
            }
            return int.Parse(damage);
        }
        private int ParseArmor(string armor)
        {
            if (this.StringIsNullAsText(armor))
            {
                return DEFAULT_ARMOR;
            }
            return int.Parse(armor);
        }
        public override string ToString()
        {
            string formatted = string.Format(TO_STRING_FORMAT, this.name, this.damage, this.health, this.armor);
            return formatted;
        }
    }

}
