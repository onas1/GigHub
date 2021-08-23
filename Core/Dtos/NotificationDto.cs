﻿using GigHub.Core.Models;
using System;

namespace GigHub.Dtos
{
    public class NotificationDto
    {

        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalValue { get; set; }
        public GigDto Gig { get; set; }
    }
}