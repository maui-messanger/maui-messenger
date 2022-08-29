﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Messenger.Client.Services;
using Messenger.Client.Views.Pages;
using Messenger.Domains.Dtos.ChatUser;
using Messenger.Domains.Dtos.User;
using Messenger.Domains.Models;
using System.Collections.ObjectModel;

namespace Messenger.Client.ViewModels
{

    public partial class DashboardPageViewModel : ObservableObject
    {

        [ObservableProperty]
        object _currentPage;

        [ObservableProperty]
        ObservableCollection<ChatUserChatsReadDto> _chats = new ObservableCollection<ChatUserChatsReadDto>();

        [ObservableProperty]
        Chat _selectedChat;

        [ObservableProperty]
        UserReadDto _user = null;

        public DashboardPageViewModel()
        {
            LoadUserInfoAsync();
        }

        public async Task LoadUserInfoAsync()
        {
            await Task.Run(async () =>
            {
                _user = await UserService.GetUserInfo(Preferences.Get("Token", ""), Preferences.Get("UserGuid", ""));
                _chats = new ObservableCollection<ChatUserChatsReadDto>(_user.UserChats);
                OnPropertyChanged("User");
                OnPropertyChanged("Chats");
            });
        }

        [RelayCommand]
        async Task GoToMessangerPage()
        {
            await Shell.Current.GoToAsync(nameof(MessangerPage));
        }

        [RelayCommand]
        async Task LoadInfoByChatModel(Chat chatModel)
        {

        }

    }
}
