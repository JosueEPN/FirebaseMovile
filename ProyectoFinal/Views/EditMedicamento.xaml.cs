namespace ProyectoFinal.Views;
using ProyectoFinal.Helpers;
using ProyectoFinal.Models;

public partial class EditMedicamento : ContentPage
{
	private FirebaseHelper firebaseHelper = new FirebaseHelper();
	private Medicamento medicamento;
	public EditMedicamento(Medicamento medicamento)
	{
		InitializeComponent();
		this.medicamento = medicamento;

		NombreEntry.Text = medicamento.Nombre;
		UnidadesEntry.Text = medicamento.Unidades.ToString();
		PrecioEntry.Text = medicamento.PrecioUnitario.ToString();
		DescripcionEntry.Text = medicamento.Descripcion;
		UbicacionEntry.Text = medicamento.Ubicacion;
        EstadoSwitch.IsToggled = medicamento.Estado;
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
		medicamento.Nombre = NombreEntry.Text;
		medicamento.Unidades = int.Parse(UnidadesEntry.Text);
		medicamento.PrecioUnitario = decimal.Parse(PrecioEntry.Text);
		medicamento.Descripcion = DescripcionEntry.Text;
		medicamento.Ubicacion = UbicacionEntry.Text;
		medicamento.Estado = EstadoSwitch.IsToggled;

		await firebaseHelper.UpdateMedicamento(medicamento.Id, medicamento);
        await DisplayAlert("Existo", "Medicamento Actualizado", "OK");
        await Navigation.PopAsync();
    }
}