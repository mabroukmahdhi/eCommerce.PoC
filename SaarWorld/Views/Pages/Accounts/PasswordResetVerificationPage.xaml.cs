// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Microsoft.Maui.Controls;
using SaarWorld.Services.Views.Pages.Accounts;

namespace SaarWorld.Views.Pages.Accounts
{
    public partial class PasswordResetVerificationPage : ContentPage
    {
        public PasswordResetVerificationPage(PasswordResetVerificationViewService passwordResetVerificationViewService)
        {
            InitializeComponent();

            this.BindingContext = passwordResetVerificationViewService;

            /* Unmerged change from project 'SaarWorld (net7.0-android)'
            Before:
                    }



                    //private async void verifyBtn_Clicked(object sender, EventArgs e)
            After:
                    }



                    //private async void verifyBtn_Clicked(object sender, EventArgs e)
            */
        }



        //private async void verifyBtn_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new PasswordResetVerifiedPage());
        //}
    }
}