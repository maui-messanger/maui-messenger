﻿using Messenger.Domains.Models;

namespace Messenger.Domains.Dtos
{
    public class UserCreateDto
    {
        //public Guid Guid { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        //public string FirstName { get; set; } = string.Empty;

        //public string Patronymic { get; set; } = string.Empty;

        //public string LastName { get; set; } = string.Empty;

        //public string Photo { get; set; } = string.Empty;

        public DateTime LastOnline { get; set; } = DateTime.Now;

        //public string Phone { get; set; } = string.Empty;

        //public string Email { get; set; } = string.Empty;

        //public bool IsBanner { get; set; } = false;

        //public bool Confirmed { get; set; } = false;

        //public IEnumerable<Chat> Chats { get; set; } = Enumerable.Empty<Chat>();
    }
}
