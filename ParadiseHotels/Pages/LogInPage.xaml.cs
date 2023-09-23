using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ParadiseHotels.Pages;

public partial class LogInPage : Page
{
    public delegate void LogInDelegate();

    private Services.Services _services;
    private LogInDelegate _logInFunc;
    private LogInDelegate _goToRegistration;
    
    public LogInPage(Services.Services services, LogInDelegate logInFunc, LogInDelegate goToRegistration)
    {
        InitializeComponent();

        _services = services;
        _logInFunc = logInFunc;
        _goToRegistration = goToRegistration;
    }

    private void LogIn_OnClick(object sender, RoutedEventArgs e)
    {
        if (_services.logIn(Email.Text, Password.Text)) _logInFunc.Invoke();
        else LogInError.Text = "Wrong email or password";
    }

    private void Register_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        _goToRegistration.Invoke();
    }

    private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        string invalidCharacters = ",\\{}[];";
        e.Handled = invalidCharacters.Contains(e.Text);
    }
}