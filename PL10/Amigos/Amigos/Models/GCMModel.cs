using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;

namespace Amigos.Models
{
    public class GCMModel
    {
        public int ID { get; set; }
        [Display(Name="ID")]
        [StringLength(4096)]
        public String regID { get; set; }
    }
}