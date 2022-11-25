using _7._Military_Elite.Enumerations;
using _7._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Military_Elite
{
    public class Mission : IMissions
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; set; }
        public State State { get; set; }

        public void CompleteMission()
        {
            State = State.finished;
        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
