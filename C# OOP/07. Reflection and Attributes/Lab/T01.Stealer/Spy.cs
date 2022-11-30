using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string Name { get; set; }
        public string[] Fields { get; set; }

        public string StealFieldInfo(string @class, params string[] fields)
        {
            Type typeClass = Type.GetType(@class);
            FieldInfo[] classFields = typeClass.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(typeClass);
            sb.AppendLine($"Class under investigation: {classInstance}");
            foreach (FieldInfo field in classFields.Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString();
        }
    }
}
