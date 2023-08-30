using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Paex2
{
    public interface DataBase
    {
        
        SQLiteAsyncConnection GetConnection();
        //el que se va a agregar en el dispositivo 

    }
}
