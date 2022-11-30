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


        public string AnalyzeAccessModifiers(string className)
        {
            Type typeClass = Type.GetType(className);
            FieldInfo[] fields = typeClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] privateMethods = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in publicMethods)
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in privateMethods)
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            Type typeClass = Type.GetType(className);
            MethodInfo[] methods = typeClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {typeClass.BaseType.Name}");


            foreach (var method in methods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }
        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            foreach (var method in methods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in methods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return sb.ToString().Trim();
        }

    }
}
