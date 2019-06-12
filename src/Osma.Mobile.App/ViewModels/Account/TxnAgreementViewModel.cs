using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using AgentFramework.Core.Models.Wallets;
using Osma.Mobile.App.Services.Interfaces;
using Osma.Mobile.App.Services.Models;
using ReactiveUI;
using Xamarin.Forms;

namespace Osma.Mobile.App.ViewModels.Account
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

        public async Task NavigateToMainPage(bool accepted)
        {
            
            await NavigationService.NavigateToAsync<MainViewModel>();
        }

        #region Bindable Commands
        public ICommand AcceptAgreementCommand => new Command(async () =>
        {
            Debug.Print("Entered AcceptAgreementCommand");
            await NavigationService.NavigateToAsync<MainViewModel>();

        });

        public ICommand RejectAgreementCommand => new Command(async () => await NavigationService.PopModalAsync());

        #endregion

        #region Bindable Properties
        private string _agreementContents = "Hello World";
        public string AgreementContents
        {
            get => _agreementContents;
            set => this.RaiseAndSetIfChanged(ref _agreementContents, value);
        }
        #endregion
    }
}
