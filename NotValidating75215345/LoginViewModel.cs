using System;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace NotValidating75215345
{
    public partial class LoginViewModel : LoginModel
    {
        private readonly ISecurityClient securityClient;

        public LoginViewModel(ISecurityClient securityClient) : base()
        {
            this.securityClient = securityClient;
        }
     
    }
}

