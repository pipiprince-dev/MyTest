using System;
using System.ComponentModel.DataAnnotations;

namespace NotValidating75215345
{
    public partial class LoginModel : BaseViewModel
    {
        protected string email;
        protected string password;


        [Required]
        [StringLength(255)]
        [MinLength(2)]
        [DataType(DataType.EmailAddress)]
        public string Email
        {
            get => this.email;
            set
            {
                ClearErrors();
                SetProperty(ref this.email, value, true);
                
                ValidateAllProperties();

                OnPropertyChanged("ErrorDictionary[Email]");
            }
        }

        [Required]
        [DataType(DataType.Password)]
        public string Password
        {
            get => this.password;
            set
            {
                SetProperty(ref this.password, value, true);

                ClearErrors();
                ValidateAllProperties();
                OnPropertyChanged("ErrorDictionary[Password]");
            }
        }
    }
}

