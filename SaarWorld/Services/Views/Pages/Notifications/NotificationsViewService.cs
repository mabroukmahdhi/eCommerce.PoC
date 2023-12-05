// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SaarWorld.Models.Notifications;
using SaarWorld.Services.Foundations.Localizations;
using SaarWorld.Services.Foundations.Notifications;
using SaarWorld.Services.Views.Bases;

namespace SaarWorld.Services.ViewModels
{
    public partial class NotificationsViewService : BaseViewService

    {

        private readonly INotificationService notificationService;

        public NotificationsViewService(ILocalizationService localizationService,
            INotificationService notificationService)
            : base(localizationService)
        {
            this.notificationService = notificationService;
            GetNotifs();
        }

        #region 
        [ObservableProperty]
        protected ObservableCollection<Notification> notifications = new ObservableCollection<Notification>();
        #endregion

        #region data proporties
        [ObservableProperty]
        protected string content;
        [ObservableProperty]
        protected string imageUrl;
        #endregion
        #region label
        [ObservableProperty]
        protected string notif;
        #endregion
        public async void GetNotifs()
        {
            try
            {
                IsBusy = true;

                List<Notification> notifs = await notificationService.GetNotif();
                Notifications = new ObservableCollection<Notification>(notifs);
            }
            catch (Exception exception)
            {
                await DisplayError(exception.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void LocalizeTexts()
        {
            Notif = GetLocalizedString("NOTIFICATIONS");

        }

    }
}