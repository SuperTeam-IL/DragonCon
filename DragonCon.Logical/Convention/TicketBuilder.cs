﻿using System;
using System.Collections.Generic;
using System.Linq;
using DragonCon.Modeling.Models.Common;
using DragonCon.Modeling.Models.Conventions;
using DragonCon.Modeling.Models.Tickets;
using NodaTime;

namespace DragonCon.Logical.Convention
{
    public class TicketBuilder
    {
        private readonly ConventionBuilder _parent;
        private readonly ConventionWrapper _convention;

        public TicketBuilder(ConventionBuilder parent, ConventionWrapper convention)
        {
            _convention = convention;
            _parent = parent;
        }

        public ConventionBuilder AddTicket(TicketType type, string ticketName, params LocalDate[] localDates)
        {
            return AddTicket(type, ticketName, localDates.ToList());
        }

        public ConventionBuilder AddTicket(TicketType type, string ticketName, List<LocalDate> localDates)
        {
            ThrowIfTicketnameEmpty(ticketName);
            ThrowIfTicketExists(ticketName);

            foreach (var date in localDates)
            {
                if (!_convention.Days.ContainsKey(date))
                    throw new Exception("Ticket-Day does not exists");
            }

            var ticket = new TicketWrapper(type)
            {
                Name = ticketName,
                Days = localDates.Select(x => _convention.Days[x]).ToList(),
                TicketType = type
            };

            _convention.NameAndTickets.Add(ticket.Name, ticket);
            return _parent;
        }


        private void ThrowIfTicketExists(string ticketName)
        {
            if (_convention.NameAndTickets.ContainsKey(ticketName))
                throw new Exception("Ticket already exists");
        }

        private void ThrowIfTicketNotExists(string ticketName)
        {
            if (!_convention.NameAndTickets.ContainsKey(ticketName))
                throw new Exception("Ticket does not exists");
        }


        private void ThrowIfTicketnameEmpty(string ticketName)
        {
            if (string.IsNullOrEmpty(ticketName) || string.IsNullOrWhiteSpace(ticketName))
                throw new Exception("Empty ticket name");   
        }

        public ConventionBuilder SetTransactionCode(string ticketName, string code)
        {
            ThrowIfTicketNotExists(ticketName);
            _convention.NameAndTickets[ticketName].TransactionCode = code;
            return _parent;
        }

        public ConventionBuilder SetNumberOfActivities(string ticketName, int i)
        {
            ThrowIfTicketNotExists(ticketName);
            ThrowIfActivityInvalid(i);
            _convention.NameAndTickets[ticketName].ActivitiesAllowed = i;
            return _parent;
        }

        private void ThrowIfActivityInvalid(int i)
        {
            if (i < 0)
                throw new Exception("Cannot set negative activities");
        }

        public ConventionBuilder SetTicketPrice(string ticketName, double price)
        {
            ThrowIfTicketNotExists(ticketName);
            ThrowIfPriceIsNotValid(price);
            _convention.NameAndTickets[ticketName].Price = price;
            return _parent;
        }

        private void ThrowIfPriceIsNotValid(double price)
        {
            if (price < 0)
                throw new Exception("Cannot set negative price");
        }

        public ConventionBuilder SetUnlimitedActivities(string ticketName)
        {
            ThrowIfTicketNotExists(ticketName);
            _convention.NameAndTickets[ticketName].ActivitiesAllowed = null;
            return _parent;
        }
    }
}