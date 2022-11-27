using EgnValidator.Enumerators;
using EgnValidator.Exceptions;
using EgnValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgnValidator
{
    public class EgnValidator : IValidator, IGenerator
    {
        private Dictionary<string, IEnumerable<int>> regions = new Dictionary<string, IEnumerable<int>>();
        private static readonly DateTime minDate = new DateTime(1800, 01, 01);
        private static readonly DateTime maxDate = new DateTime(2099, 12, 31);
        private int[] egnWeights = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        public EgnValidator()
        {
            regions = new Dictionary<string, IEnumerable<int>>();
            regions.Add("Благоевград", Enumerable.Range(0, 44));
            regions.Add("Бургас", Enumerable.Range(44, 50));
            regions.Add("Варна", Enumerable.Range(94, 46));
            regions.Add("Велико Търново", Enumerable.Range(140, 30));
            regions.Add("Видин", Enumerable.Range(170, 14));
            regions.Add("Враца", Enumerable.Range(184, 34));
            regions.Add("Габрово", Enumerable.Range(218, 16));
            regions.Add("Кърджали", Enumerable.Range(234, 48));
            regions.Add("Кюстендил", Enumerable.Range(282, 20));
            regions.Add("Ловеч", Enumerable.Range(302, 18));
            regions.Add("Монтана", Enumerable.Range(320, 22));
            regions.Add("Пазарджик", Enumerable.Range(342, 36));
            regions.Add("Перник", Enumerable.Range(378, 18));
            regions.Add("Плевен", Enumerable.Range(396, 40));
            regions.Add("Пловдив", Enumerable.Range(436, 66));
            regions.Add("Разград", Enumerable.Range(502, 26));
            regions.Add("Русе", Enumerable.Range(528, 28));
            regions.Add("Силистра", Enumerable.Range(556, 20));
            regions.Add("Сливен", Enumerable.Range(576, 26));
            regions.Add("Смолян", Enumerable.Range(602, 22));
            regions.Add("София - град", Enumerable.Range(624, 98));
            regions.Add("София - окръг", Enumerable.Range(722, 30));
            regions.Add("Стара Загора", Enumerable.Range(752, 38));
            regions.Add("Добрич", Enumerable.Range(790, 32));
            regions.Add("Търговище", Enumerable.Range(822, 22));
            regions.Add("Хасково", Enumerable.Range(844, 28));
            regions.Add("Шумен", Enumerable.Range(872, 32));
            regions.Add("Ямбол", Enumerable.Range(904, 22));
            regions.Add("Друг", Enumerable.Range(926, 74));
        }

        /// <summary>
        /// Generate all valid EGN numbers for given criteria.
        /// </summary>
        /// <param name="birthDate">Date of birth.</param>
        /// <param name="city">The city where EGN holders are born in.</param>
        /// <param name="isMale">True for male, false for female</param>
        /// <returns>List of all valid EGN numbers</returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidCityException"></exception>
        public string[] Generate(DateTime birthDate, string city, Gender gender)
        {
            if (birthDate.Year < minDate.Year || birthDate.Year > maxDate.Year)
            {
                throw new ArgumentOutOfRangeException("birthDate", "Birth date should be greater or equal to 1800");
            }
            if (city == null)
            {
                throw new ArgumentNullException(city);
            }
            if (!regions.ContainsKey(city))
            {
                throw new InvalidCityException(city);
            }
            if (gender != Gender.Male && gender != Gender.Female)
            {
                throw new ArgumentOutOfRangeException("gender", "Gender should be 1 for male,2 for female");
            }
            StringBuilder date = GenerateDateOfBirthday(birthDate);
            List<StringBuilder> EgnCollection = new List<StringBuilder>();
            foreach (var regionCode in regions[city])
            {
                StringBuilder egnToAdd = new StringBuilder(date.ToString());

                if (gender == Gender.Male)
                {
                    if (regionCode % 2 == 0)
                    {
                        egnToAdd.Append(regionCode);
                        EgnCollection.Add(egnToAdd);
                    }
                }
                else
                {
                    if (regionCode % 2 != 0)
                    {
                        egnToAdd.Append(regionCode);
                        EgnCollection.Add(egnToAdd);
                    }
                }
            }
            return GenerateControl(EgnCollection).Select(x => x.ToString()).ToArray();
        }

        private List<StringBuilder> GenerateControl(List<StringBuilder> egnCollection)
        {
            for (int i = 0; i < egnCollection.Count; i++)
            {
                string egn = egnCollection[i].ToString();
                int controlNum = 0;

                for (int j = 0; j < 9; j++)
                {
                    controlNum += int.Parse(egn[j].ToString()) * egnWeights[j];
                }
                controlNum %= 11;
                if (controlNum == 10)
                {
                    egnCollection[i].Append(0);
                }
                else
                {
                    egnCollection[i].Append(controlNum);
                }
            }
            return egnCollection;
        }

        private StringBuilder GenerateDateOfBirthday(DateTime birthDate)
        {
            StringBuilder egn = new StringBuilder();
            int year = birthDate.Year;
            int month = birthDate.Month;
            int day = birthDate.Day;
            if (year < 1900 && year >= minDate.Year)
            {
                year -= 1800;
                month += 20;
            }
            else if (year > 1999 && year <= maxDate.Year)
            {
                year -= 2000;
                month += 40;
            }
            else
            {
                year -= 1900;
            }
            egn.Append($"{year:d2}{month:d2}{day:d2}");
            return egn;
        }

        public bool Validate(string egn)
        {
            if (string.IsNullOrEmpty(egn) || string.IsNullOrWhiteSpace(egn) || egn.Length != 10)
            {
                return false;
            }
            if (!long.TryParse(egn, out _))
            {
                return false;
            }
            string[] egnValues = egn.ToCharArray().Select(x => x.ToString()).ToArray();
            if (ValidateDate(egnValues) && ValidateRegion(egnValues) && ValidateControl(egnValues))
            {
                return true;
            }
            return false;
        }

        private bool ValidateControl(string[] egnValues)
        {
            int controlNum = int.Parse(egnValues[^1]);
            int result = 0;
            for (int i = 0; i < 9; i++)
            {
                result += int.Parse(egnValues[i]) * egnWeights[i];
            }
            result %= 11;
            if (result == 10)
            {
                return controlNum == 0;
            }
            return controlNum == result;
        }

        private bool ValidateRegion(string[] egnValues)
        {
            int regionCode = int.Parse($"{egnValues[6]}{egnValues[7]}{egnValues[8]}");
            foreach (var region in regions)
            {
                if (region.Value.Contains(regionCode))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidateDate(string[] egnValues)
        {
            int year = int.Parse($"{egnValues[0]}{egnValues[1]}");
            int month = int.Parse($"{egnValues[2]}{egnValues[3]}");
            int day = int.Parse($"{egnValues[4]}{egnValues[5]}");
            if (month > 0 && month <= 12)
            {
                year += 1900;

            }
            else if (month >= 21 && month <= 32)
            {
                year += 1800;
                month -= 20;
            }
            else if (month >= 41 && month <= 52)
            {
                year += 2000;
                month -= 40;
            }
            else return false;

            try
            {
                DateTime date = new DateTime(year, month, day);
                if (date >= minDate && date <= maxDate)
                {
                    return true;
                }
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
    }
}
