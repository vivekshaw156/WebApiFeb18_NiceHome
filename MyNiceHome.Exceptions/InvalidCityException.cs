﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Exceptions
{
    public class InvalidCityException:Exception
    {
        public InvalidCityException(string message):base(message)
        {

        }
    }
}
