using System;
using System.Collections.Generic;
using System.Text;

namespace _4._Border_Control
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
