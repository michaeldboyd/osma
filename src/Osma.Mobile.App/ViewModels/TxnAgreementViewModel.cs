using System;
using System.Windows.Input;
using Acr.UserDialogs;
using AgentFramework.Core.Models.Wallets;
using Osma.Mobile.App.Services.Interfaces;
using Osma.Mobile.App.Services.Models;
using Xamarin.Forms;

namespace Osma.Mobile.App.ViewModels
{
    public class TxnAgreementViewModel : ABaseViewModel
    {
        private readonly ICustomAgentContextProvider _agentContextProvider;

        public TxnAgreementViewModel(IUserDialogs userDialogs,
                                 INavigationService navigationService,
                                 ICustomAgentContextProvider agentContextProvider) : base(
                                 nameof(TxnAgreementViewModel),
                                 userDialogs,
                                 navigationService)
        {
            _agentContextProvider = agentContextProvider;
        }

        #region Bindable Commands
        public ICommand Accept => new Command(async () =>
        {
            var dialog = UserDialogs.Instance.Alert("Accepted");

            await NavigationService.NavigateToAsync<MainViewModel>();
            dialog?.Dispose();
        });

        public ICommand Reject => new Command(async () =>
        {
            var dialog = UserDialogs.Instance.Loading("Rejected");

            await NavigationService.NavigateToAsync<MainViewModel>();
            dialog?.Dispose();

        });
        #endregion
    }
}
