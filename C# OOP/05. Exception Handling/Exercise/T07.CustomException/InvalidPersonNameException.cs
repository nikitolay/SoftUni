﻿using System;
using System.Collections.Generic;
using System.Text;

namespace T07.CustomException
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string msg)
            : base(msg)
        {

        }
    }
}
