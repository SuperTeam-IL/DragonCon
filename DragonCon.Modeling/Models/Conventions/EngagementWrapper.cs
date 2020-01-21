﻿using System.Collections.Generic;
using DragonCon.Modeling.Models.Common;
using DragonCon.Modeling.Models.Events;
using DragonCon.Modeling.Models.Identities;

namespace DragonCon.Modeling.Models.Conventions
{
    public class EngagementWrapper : Wrapper<UserEngagement>
    {
        public EngagementWrapper()
        {

        }
        public EngagementWrapper(UserEngagement engagement) 
            : base(engagement)
        {

        }

        public IParticipant Participant { get; set; }
        public Convention Convention { get; set; }
        public List<EngagedEvent> Events { get; set; } = new List<EngagedEvent>();
        public List<EngagedEvent> SuggestedEvents { get; set; } = new List<EngagedEvent>();
    }

    public class EngagedEvent
    {
        public Event Event;

        public EngagedEvent(Event item)
        {
            Event = item;
        }

        public Day Day { get; set; }

        public string Hall { get; set; }
        public int Table { get; set; }
    }
}