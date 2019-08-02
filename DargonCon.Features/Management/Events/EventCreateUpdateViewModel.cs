﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonCon.Logical.Factories;
using DragonCon.Modeling.Models.Common;
using DragonCon.Modeling.Models.Conventions;
using DragonCon.Modeling.Models.Events;
using DragonCon.Modeling.Models.HallsTables;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DragonCon.Features.Management.Events
{
    public class EventCreateUpdateViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ConventionDayId { get;set; }
        public string SystemId { get;set; }

        public string GameMasterId { get; set; }
        public List<string> HelperIds { get; set; }

        public EventStatus Status { get; set; }
        public TimeSlot TimeSlot { get;set; }
        public SizeRestriction Size { get;set; }
        public string AgeRestrictionId { get; set; }
        
        public List<string> Tags { get;set; }
        public int? Table { get; set; }
        
        public string Description { get; set; }
        public string SpecialRequests { get;set; }


        #region Selectors

        public Dictionary<Day, TimeSlotOptions> GetDayOptions()
        {
            var result = new Dictionary<Day, TimeSlotOptions>();
            var factory = new StrategyFactory();
            foreach (var day in Days)
            {
                result.Add(day, factory.TimeSlots(day.StartTime, day.EndTime, day.TimeSlotStrategy));
            }

            return result;
        }


        public List<AgeRestriction> AgeRestrictions { get; set; }
        public List<SelectListItem> GetAgeRestrictionDropDown
        {
            get
            {
                var items = new List<SelectListItem>();
                foreach (var age in AgeRestrictions.OrderBy(x => x.Name))
                {
                    var item = new SelectListItem
                    {
                        Value = age.Id,
                        Text = age.GetDescription(),
                    };
                    items.Add(item);
                }

                return items;
            }
        }

        public List<EventActivity> Activities { get; set; }
        public List<SelectListItem> GetActivitiesDropDown
        {
            get
            {
                var items = new List<SelectListItem>();
                foreach (var eventActivity in Activities.OrderBy(x => x.Name))
                {
                    var group = new SelectListGroup {Name = eventActivity.Name};
                    items.Add(new SelectListItem
                    {
                        Value = eventActivity.Id,
                        Text = "כללי",
                        Group = group
                    });

                    foreach (var system in eventActivity.ActivitySystems.OrderBy(x => x.Name))
                    {
                        var item = new SelectListItem
                        {
                            Value = system.Id,
                            Text = system.Name,
                            Group = group
                        };
                        items.Add(item);
                    }
                }

                return items;
            }
        }
        public IEnumerable<Day> Days { get; set; }
        public List<SelectListItem> GetDaysDropDown
        {
            get
            {
                var items = new List<SelectListItem>();
                foreach (var day in Days.OrderBy(x => x.Date))
                {
                    var item = new SelectListItem
                    {
                        Value = day.Id,
                        Text = day.GetDescription()
                    };
                    items.Add(item);
                }

                return items;
            }
        }

        public IEnumerable<Hall> Halls { get; set; }
        public List<SelectListItem> GetHallsDropdown
        {
            get
            {
                var items = new List<SelectListItem>();
                foreach (var halls in Halls.OrderBy(x => x.FirstTable))
                {
                    var group = new SelectListGroup {Name = halls.Name};
                    foreach (var table in halls.Tables.OrderBy(x => x))
                    {
                        var item = new SelectListItem
                        {
                            Value = table.ToString(),
                            Text = $"שולחן {table}",
                            Group = group
                        };
                        items.Add(item);
                    }
                }

                return items;
            }
        }

        #endregion
    }
}
