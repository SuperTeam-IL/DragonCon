﻿using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonCon.Modeling.Models.News
{
    public class NewsItem
    {
        public Instant Timestamp { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
    }
}
