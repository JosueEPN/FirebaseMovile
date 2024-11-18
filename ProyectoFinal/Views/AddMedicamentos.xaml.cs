using ProyectoFinal.Helpers;
using ProyectoFinal.Models;

namespace ProyectoFinal.Views;

public partial class AddMedicamentos : ContentPage
{
	FirebaseHelper firebaseHelper = new FirebaseHelper();
	public AddMedicamentos()
	{
		InitializeComponent();
	}

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
		var medicamento = new Medicamento
		{
			Nombre = NombreEntry.Text,
			Unidades = int.Parse(UnidadesEntry.Text),
			PrecioUnitario = decimal.Parse(PrecioEntry.Text),
			Descripcion = DescripcionEntry.Text,
			Ubicacion = UbicacionEntry.Text,
			Estado = EstadoSwitch.IsToggled
		};

        await firebaseHelper.AddMedicamento(medicamento);
		await DisplayAlert("Existo", "Medicamento Agregado", "OK");
        await Navigation.PopAsync();
    }
}