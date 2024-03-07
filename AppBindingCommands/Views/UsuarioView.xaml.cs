namespace AppBindingCommands.Views;

using AppBindingCommands.ViewModel;

public partial class UsuarioView : ContentPage
{
	public UsuarioView()
	{
		InitializeComponent();
		BindingContext = new UsuarioViewModel();
	}
}