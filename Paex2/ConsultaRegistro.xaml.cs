using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.Collections.ObjectModel;

namespace Paex2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        SQLiteAsyncConnection con;
        //tipo contenedor alamcena temporalmente
        ObservableCollection<Estudiante> tEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();

            con = DependencyService.Get<DataBase>().GetConnection();

            //para mostrar los datos 
            mostrar();

        }


        //elemento para mostrar los datos 

        public async void mostrar()
        {
            var resultado = await con.Table<Estudiante>().ToListAsync();
            //guardo los datos en esa variable 
            tEstudiante = new ObservableCollection<Estudiante>(resultado);
            ListaEstudiante.ItemsSource = tEstudiante;
        }
        private void ListaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //creo un objeto y capturo 
            var obj = (Estudiante)e.SelectedItem;
            //se puede ver el obetjo 
            Navigation.PushAsync(new Elemento(obj));

            //creo el elemento 


        }
    }
}