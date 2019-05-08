﻿using System;
using System.Collections.Generic;
using System.Text;
using DragonCon.Modeling.Models.Conventions;
using DragonCon.Modeling.Models.HallsTables;

namespace DragonCon.Features.Management.Convention
{
    public class ConventionUpdateViewModel
    {
        public NameDatesCreateUpdateViewModel NameDate { get; set; }
        public TicketsUpdateViewModel Tickets { get; set; }
        public HallsUpdateViewModel Halls { get; set; }
        public DetailsUpdateViewModel Details { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class DetailsUpdateViewModel
    {
        public Dictionary<string, string> Metadata { get; set; }
        public List<PhoneRecord> Phonebook { get; set; }
    }

    public class HallsUpdateViewModel{
        public List<HallWrapper> Halls { get; set; }
    }

}
