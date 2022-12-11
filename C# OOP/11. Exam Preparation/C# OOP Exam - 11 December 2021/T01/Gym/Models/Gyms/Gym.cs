using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Equipment = new List<IEquipment>();
            Athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight
            => Equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment { get; private set; }

        public ICollection<IAthlete> Athletes { get; private set; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity == Athletes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
                => Equipment.Add(equipment);

        public void Exercise()
        {
            foreach (var athete in Athletes)
            {
                athete.Exercise();
            }
        }
        /// <summary>
        /// ///////////////////////
        /// </summary>
        /// <returns></returns>
        public string GymInfo()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{Name} is a {this.GetType().Name}:");
            string athletess = Athletes.Count > 0 ? string.Join(", ", Athletes) : "No athletes";
            result.AppendLine($"Athletes: {athletess}");
            result.AppendLine($"Equipment total count: {Equipment.Count}");
            result.AppendLine($"Equipment total weight: {Equipment.Sum(x => x.Weight):f2} grams");
            return result.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
                => Athletes.Remove(athlete);
    }
}
