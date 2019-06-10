using System;
using System.Threading.Tasks;
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

        public async Task NavigateToMainPage(bool accepted)
        {
            await NavigationService.NavigateToAsync<MainViewModel>();
        }

        #region Bindable Commands
        public ICommand AcceptCommand => new Command(async () => await NavigateToMainPage(true));

        public ICommand RejectCommand => new Command(async () => await NavigateToMainPage(false));
    
        #endregion
    }
}
