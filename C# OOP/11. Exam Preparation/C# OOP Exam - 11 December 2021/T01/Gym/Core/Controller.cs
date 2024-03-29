﻿using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;


        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            IAthlete athlete;

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);

            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if (gym.GetType().Name == "BoxingGym" && athleteType != "Boxer" || gym.GetType().Name == "WeightliftingGym" && athleteType != "Weightlifter")
            {
                return OutputMessages.InappropriateGym;
            }

            gym.AddAthlete(athlete);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            this.equipment.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            double weight = 0;
            foreach (var equipment in gyms.Where(x=>x.Name == gymName))
            {
                weight += equipment.EquipmentWeight;
            }
            return string.Format(OutputMessages.EquipmentTotalWeight,gymName, weight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            IEquipment equipment = this.equipment.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);

        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            foreach (var gym in gyms)
            {
                result.AppendLine(gym.GymInfo());
            }
            return result.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {

            int count = 0;
            foreach (var athlete in gyms.FirstOrDefault(x => x.Name == gymName).Athletes)
            {
                athlete.Exercise();
                count++;
            }
            return string.Format(OutputMessages.AthleteExercise, count);
        }
    }
}
