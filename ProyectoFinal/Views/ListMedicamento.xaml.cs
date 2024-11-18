namespace ProyectoFinal.Views;
using ProyectoFinal.Helpers;
using ProyectoFinal.Models;

public partial class ListMedicamento : ContentPage
{
	FirebaseHelper firebaseHelper = new FirebaseHelper();
	public ListMedicamento()
	{
		InitializeComponent();
		LoadMedicamentos();
	}

    private async void LoadMedicamentos()
    {
        var medicamento = await firebaseHelper.GetMedicamentos();
        listaMedicamentos.ItemsSource = medicamento; // Asigna la lista
        
    }


    private void listaMedicamentos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        
    }

    private async void btnEditar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var medicamento = button?.BindingContext as Medicamento;
        if (medicamento != null) 
        {
            await Navigation.PushAsync(new EditMedicamento(medicamento));
        }

    }
    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var medicamento = button?.BindingContext as Medicamento;
        if(medicamento != null && !string.IsNullOrEmpty(medicamento.Id))
        {
            await firebaseHelper.DeleteMedicamento(medicamento.Id);
            await DisplayAlert("Existo", "Medicamento Eliminado", "OK");
            LoadMedicamentos();
        }
        else 
        {
            DisplayAlert("Error", "No se pudo eliminar el medicamento", "OK");
        }

    }

    private async void btnCrearMedicamento_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddMedicamentos());
    }
}