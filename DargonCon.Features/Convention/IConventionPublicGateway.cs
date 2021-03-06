﻿using DragonCon.Features.Convention.Home;
using DragonCon.Features.Convention.Landing;
using DragonCon.Features.Shared;

namespace DragonCon.Features.Convention
{
    public interface IConventionPublicGateway : IGateway
    {
        HomeViewModel BuildHome();
        LandingViewModel BuildLanding();

        // TODO build English
        // TODO Build Info
    }
}