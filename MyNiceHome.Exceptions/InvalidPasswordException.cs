﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNiceHome.Exceptions
{
    public class InvalidPasswordException:Exception
    {
        public InvalidPasswordException(string message):base(message)
        {
               
        }
    }
}
