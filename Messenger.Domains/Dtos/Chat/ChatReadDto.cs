﻿using Enums;
using Messenger.Domains.Dtos.ChatUser;

namespace Messenger.Domains.Dtos.Chat
{
    public class ChatReadDto
    {
        public Guid GlobalGuid { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public string About { get; set; }

        public ChatType Type { get; set; }

        public List<ChatUserReadDto> Users { get; set; }
    }
}
