using ExamenProg3JuanMino.Models;

namespace ExamenProg3JuanMino.Views;

public partial class GaleriaPage : ContentPage
{
	public GaleriaPage()
	{
		InitializeComponent();
        List<Imagen> im = App.Repositorio.GetAllImg();
        listaImg.ItemsSource = im;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        List<Imagen> im = App.Repositorio.GetAllImg();
        listaImg.ItemsSource = im;
    }

    private async void Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var Imagen = (Models.Imagen)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(NewImagePage)}?{nameof(NewImagePage.ItemId)}={Imagen.IdJM}");

            // Unselect the UI
            listaImg.SelectedItem = null;
        }
    }

    private void GoToNewImagePage(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NewImagePage));
    }
}