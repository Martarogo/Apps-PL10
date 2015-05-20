﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;

namespace Amigos.Models
{
    public class Amigo
    {
        public int ID { get; set; }
        [Display(Name = "Nombre")]
        public string name { get; set; }
        [Display(Name = "Longitud")]
        public string longi { get; set; }
        [Display(Name = "Latitud")]
        public string lati { get; set; }

        public double getDistance(Amigo a)
        {
            GeoCoordinate me = new GeoCoordinate(Convert.ToDouble(lati),Convert.ToDouble(longi));
            GeoCoordinate friend = new GeoCoordinate(Convert.ToDouble(a.lati),Convert.ToDouble(a.longi));
            return me.GetDistanceTo(friend); 
           //Distancia entre 2 ubicaciones, en metros
            //Utiliza la fórmula Haversine, responsable de la curvatura de la tierra, suponiéndola esférica en lugar de un elipsoide. 
            //Para largas distancias, la fórmula Haversine introduce un error menor de 0,1 por ciento.
        }
    }
}