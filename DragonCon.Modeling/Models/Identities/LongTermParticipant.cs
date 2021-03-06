﻿using System;
using System.Collections.Generic;
using DragonCon.Modeling.Helpers;
using Raven.Identity;

namespace DragonCon.Modeling.Models.Identities
{
    public class LongTermParticipant : IdentityUser, IParticipant
    {
        public bool IsAllowingPromotions { get; set; }
        public int YearOfBirth { get; set; }

        public string FirstName
        {
            get
            {
                try
                {
                    var breakName = FullName.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                    return breakName[0].Trim();
                }
                catch
                {
                    return FullName;
                }
            }
        }

        public string FullName { get; set; }

        #region Roles 
        // We must Override this Property.
        public override IReadOnlyList<string> Roles => new List<string>();

        public IList<SystemRoles> SystemRoles { get; } = new List<SystemRoles>();

        
        public bool HasRole(SystemRoles role)
        {
            return SystemRoles.Contains(role);
        }

        public void AddRole(SystemRoles role)
        {
            if (SystemRoles.Missing(role))
                SystemRoles.Add(role);
        }

        public void RemoveRole(SystemRoles role)
        {
            if (SystemRoles.Contains(role))
                SystemRoles.Remove(role);
        }
        #endregion
    }
}