﻿using System;
using System.Collections.Generic;
using System.Text;
using DragonCon.Logical.Gateways.Users;
using DragonCon.Modeling.Models.Common;
using DragonCon.Modeling.Models.Identities;
using DragonCon.Modeling.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents.Session;

namespace DragonCon.Gateway.RavenDB.Controllers.Users
{
    [Area("Users")]
    [Authorize]

    public class EventsController  : DragonController<IEventsGateway>
    {
        public EventsController(IEventsGateway gateway) : 
            base(gateway)  { }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SuggestAnEvent()
        {
            return View(new SuggestEventViewModel()
            {
                // TODO add selections
            });
        }

        [HttpPost]
        public IActionResult SuggestAnEvent(SuggestEventViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Answer ans = Gateway.AddSuggestedEvent(viewmodel);
                if (ans.AnswerType == AnswerType.Error)
                    //TODO implement error shower
                    // TODO Log..
                    return View(viewmodel);
                else
                    return RedirectToAction("Index");
            }
            else
            {
                return View(viewmodel);
            }
        }

    }
}
