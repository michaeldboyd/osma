﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Osma.Mobile.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TxnAgreementPage : ContentPage, IRootView
    {
        public TxnAgreementPage()
        {
            InitializeComponent();
        }
    }
}