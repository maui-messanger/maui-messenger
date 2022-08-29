﻿using Messenger.Domains.Dtos.User;
using Messenger.Domains.Enums;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Messenger.Domains.Dtos.Chat
{
    public class ChatUserReadDto
    {
        public UserReadResponse User { get; set; }

        public Guid GlobalGuid { get; set; }

        public UserReadResponse InviterUser { get; set; }

        public bool Deleted { get; set; } = false;

        public bool Banned { get; set; } = false;

        public bool IsMuted { get; set; } = false;

        public ChatRole UserRole { get; set; } = ChatRole.Default;

        public DateTime Joined { get; set; } = DateTime.Now;

        public DateTime? MuteEnd { get; set; }
    }
}
