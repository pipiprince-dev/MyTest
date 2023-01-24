namespace NotValidating75215345;

public partial class LoginPage : ContentPage
{
    private LoginViewModel viewModel => BindingContext as LoginViewModel;

    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();

        viewModel.ValidationCompleted += OnValidationHandler;
        BindingContext = viewModel;
    }

    private void OnValidationHandler(Dictionary<string, string> validationMessages)
    {
        if (validationMessages is null)
            return;

        lblValidationErrorEmail.Text = validationMessages.GetValueOrDefault("email");
        lblValidationErrorPassword.Text = validationMessages.GetValueOrDefault("password");
    }
}
