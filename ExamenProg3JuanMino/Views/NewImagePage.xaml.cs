using ExamenProg3JuanMino.Models;
namespace ExamenProg3JuanMino.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NewImagePage : ContentPage
{
    Imagen Item = new Imagen();
    Imagen aux = new Imagen();
    string img;

    public int ItemId
    {
        set { cargarImagen(value); }
    }

    public NewImagePage()
	{
		InitializeComponent();
	}

    private async void guardarImg(object sender, EventArgs e)
    {
        if (BindingContext == null)
        {
            Item.TituloJM = titJM.Text;
            Item.DescripcionJM = descJM.Text;
            Item.TecnicaJM = tecJM.Text;
            Item.FechaJM = DateTime.Now;
            Item.ImgJM = img;
            int error = App.Repositorio.insertImg(Item);
            if (error == 404)
            {
                await DisplayAlert("Alerta", "No se pudo ingresar la mascota", "OK");
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        else
        {
            App.Repositorio.actualizarImg(aux.IdJM,
                aux.TituloJM,
                aux.TecnicaJM,
                aux.DescripcionJM,
                img);
            await Shell.Current.GoToAsync("..");
        }

    }

    private async void eliminarImg(object sender, EventArgs e)
    {
        App.Repositorio.eliminarImg(aux.IdJM);
        await Shell.Current.GoToAsync("..");
    }

    private void cargarImagen(int id)
    {
        Imagen i = new Models.Imagen();
        i = App.Repositorio.GetById(id);
        aux = i;
        BindingContext = i;
    }

    private void Cancelar(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    public async void generarImg(object sender, EventArgs e)
    {
        input inp = new input() { size = "256x256", n = 1 };
        inp.prompt = descJM.Text;
        responseModel resp;
        resp = await App.API.GenerateImage(inp);
        try
        {
            Uri imageurl = new Uri(resp.data[0].url);
            imgJM.Source = ImageSource.FromUri(imageurl);
            img = imageurl.ToString();
        }
        catch (Exception)
        {
            await Application.Current.MainPage.DisplayAlert("Alerta", "No se logró contactar a la API", "OK");
        }
    }
}