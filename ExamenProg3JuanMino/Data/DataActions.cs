using ExamenProg3JuanMino.Models;
using SQLite;

namespace ExamenProg3JuanMino.Data
{
    public class DataActions
    {
        string _dbPath;                                  
        private SQLiteConnection conn;                 

        public DataActions(string DatabasePath)    
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn != null)                           
                return;
            conn = new SQLiteConnection(_dbPath);        
            conn.CreateTable<Imagen>();      
        }

        public int insertImg(Imagen img)         
        {
            Init();
            try
            {
                int result = conn.Insert(img);
                return result;
            }
            catch (Exception)
            {
                return 404;
            }
        }

        public List<Imagen> GetAllImg()           
        {
            Init();
            List<Imagen> imgs = conn.Table<Imagen>().ToList();
            return imgs;
        }

        public Imagen GetById(int id)
        {
            Init();
            var img = from i in conn.Table<Imagen>()
                         where i.IdJM == id
                         select i;

            return img.FirstOrDefault();
        }

        public void actualizarImg(int id,string tit,string tec,string des,string im)
        {
            Init();
            var actualizada = conn.Table<Imagen>().Where(r => r.IdJM == id).FirstOrDefault();
            if (actualizada != null)
            {
                actualizada.TituloJM = tit;
                actualizada.TecnicaJM = tec;
                actualizada.DescripcionJM = des;
                actualizada.ImgJM = im;
                actualizada.FechaJM = DateTime.Now;

                conn.Update(actualizada);
            }
        }

        public void eliminarImg(int id)
        {
            var imgEliminar = conn.Table<Imagen>().Where(r => r.IdJM == id).FirstOrDefault();
            if (imgEliminar != null)
            {
                conn.Delete(imgEliminar);
            }

        }
    }
}
