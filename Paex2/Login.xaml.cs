using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Paex2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        //crear una variable global de tipo conexion
        private SQLiteAsyncConnection con;

        public Login()
        {
            InitializeComponent();
            //se va a conectar a travez del database y llamo al metodo
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        //creo el metodo que me permite general el sql 

        public static IEnumerable<Estudiante>select_where(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario=? and Contrasena=?", usuario, contrasena);
             
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //accedo a la ruta donde esta la base de datos
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);

                //creo la tabla 
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = select_where(db , txtUsuario.Text, txtContrasena.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("ERROR", "USUARIO/CONTRASEÑA INCORRECTA", "Cerrar");
                }
            }
            catch (Exception)
            {

                //throw;
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}