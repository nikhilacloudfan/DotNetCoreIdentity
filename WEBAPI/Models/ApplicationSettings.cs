﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class ApplicationSettings
    {
        public string JWT_SECRET { get; set; }
        public string Client_URL { get; set; }
    }
}
