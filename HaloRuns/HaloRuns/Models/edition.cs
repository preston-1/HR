﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HaloRuns.Models
{
    public class Edition
    {
        [Helpers.RouteModelBindKey]
        public int Id { get; set; }

        [DisplayName("Edition Name")] 
        public string Name { get; set; } 

        public int GameId { get; set; }

        public Game Game {get; set; }
        public int PlatformId { get; set; }

    }
}
