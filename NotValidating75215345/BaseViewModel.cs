using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NotValidating75215345
{
    public delegate void NotifyWithValidationMessages(Dictionary<string, string?> validationDictionary);

    public partial class BaseViewModel : ObservableValidator
    {
        public event NotifyWithValidationMessages? ValidationCompleted;
        public virtual ICommand ValidateCommand => new RelayCommand(() => ValidateModel());

        private ValidationContext validationContext;

        public BaseViewModel()
        {
            validationContext = new ValidationContext(this);
        }

        [IndexerName("ErrorDictionary")]
        public ValidationStatus this[string propertyName]
        {
            get
            {
                //ClearErrors();
                ValidateAllProperties();

                var errors = this.GetErrors()
                                 .ToDictionary(k => k.MemberNames.First(), v => v.ErrorMessage) ?? new Dictionary<string, string?>();

                var hasErrors = errors.TryGetValue(propertyName, out var error);
                return new ValidationStatus(hasErrors, error ?? string.Empty);
            }
        }

        private void ValidateModel()
        {
            //ClearErrors();
            ValidateAllProperties();

            var validationMessages = this.GetErrors()
                                         .ToDictionary(k => k.MemberNames.First().ToLower(), v => v.ErrorMessage);

            ValidationCompleted?.Invoke(validationMessages);
        }
    }

    public class ValidationStatus : ObservableObject
    {
        private bool hasError;
        private string error;

        public bool HasError
        {
            get => this.hasError;
            set => SetProperty(ref this.hasError, value);
        }

        public string Error
        {
            get => this.error;
            set => SetProperty(ref this.error, value);
        }

        public ValidationStatus(bool hasError, string error)
        {
            HasError = hasError;
            Error = error;
        }
    }
}

