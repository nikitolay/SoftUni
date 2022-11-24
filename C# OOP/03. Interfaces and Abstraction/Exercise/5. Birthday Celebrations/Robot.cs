using System;
using System.Collections.Generic;
using System.Text;

namespace _5._Birthday_Celebrations
{
    public class Robot : IIdentifiable
    {
        public Robot(string make, string id)
        {
            Make = make;
            Id = id;
        }

        public string Make { get; set; }
        public string Id { get ; set; }

    }
}
