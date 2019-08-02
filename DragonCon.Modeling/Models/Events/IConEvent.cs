﻿using System.Collections.Generic;
using DragonCon.Modeling.Models.Common;

namespace DragonCon.Modeling.Models.Events
{
    public interface IConEvent
    {
        string ActivityId { get; set; }
        string AgeId { get; set; }
        string SpecialRequests { get; set; }
        string ConventionDayId { get; set; }
        string Description { get; set; }
        string GameMasterId { get; set; }
        List<string> HelperIds { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        List<string> ParticipantIds { get; set; }
        SizeRestriction Size { get; set; }
        EventStatus Status { get; set; }
        string SystemId { get; set; }
        string HallId { get; set; }
        int? Table { get; set; }
        List<string> Tags { get; set; }
        TimeSlot TimeSlot { get; set; }
        List<EventHistory> StatusHistory { get;set; }
    }
}