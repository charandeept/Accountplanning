﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Models.BusinessModels
{
    public class RoadMapDetailsBM
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
