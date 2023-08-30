using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using Paex2.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(ClienteAndroid))]

namespace Paex2.Droid
{
    //implementando la interfaz
    public class ClienteAndroid : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            //crear el archivo para la base de datos en mis documentos
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //la base de datos 
            var baseDatos = Path.Combine(ruta, "uisrael.db3");
            return new SQLiteAsyncConnection(baseDatos);
            //creado el metodo 



        }
    }
}