using System.ComponentModel;

namespace ExamenProg3JuanMino.ViewModel
{
    public class ImgViewModel : INotifyPropertyChanged
    {
        string fecha;
        
        public string Fecha
        {
            get => Fecha;
            set
            {
                fecha = value;
                OnPropertyChanged(nameof(Fecha));
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
