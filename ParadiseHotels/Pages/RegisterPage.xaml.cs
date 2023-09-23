using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ParadiseHotels.Pages;

public partial class RegisterPage : Page
{
    public delegate void RegisterClick();

    private RegisterClick _registerClick;
    private RegisterClick _goToLogIn;
    private Services.Services _services;
    
    public RegisterPage(Services.Services services, RegisterClick registerClick, RegisterClick goToLogIn)
    {
        InitializeComponent();

        _registerClick = registerClick;
        _goToLogIn = goToLogIn;
        _services = services;
    }

    private void Register_OnClick(object sender, RoutedEventArgs e)
    {
        RegistrationError.Text = "";
        
        Services.Services.registerErrors error = _services.registerUser(
            FirstName.Text,
            LastName.Text,
            MiddleName.Text,
            Email.Text,
            Password.Text,
            Phone.Text,
            City.Text,
            Address.Text);

        if (error == Services.Services.registerErrors.EmailIsTaken)
            RegistrationError.Text = "This email is already taken!";
        if (error == Services.Services.registerErrors.PhoneIsTaken)
            RegistrationError.Text = "This phone number is already taken!";
        if (error == Services.Services.registerErrors.EmptyField)
            RegistrationError.Text = "All fields are required";
        
        if (error == Services.Services.registerErrors.Success) _registerClick.Invoke();
    }

    private void LogIn_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        _goToLogIn.Invoke();
    }
    
    private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        string invalidCharacters = ",\\{}[];";
        e.Handled = invalidCharacters.Contains(e.Text);
    }
}