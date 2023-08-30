﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paex2
{
    public class Estudiante
    {
        //primero el tipo de dato 
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Usuario { get; set; }

        [MaxLength(50)]
        public string Contrasena { get; set;}


    }
}
