using System;
using System.ComponentModel.DataAnnotations;

namespace PRPC_CIDM4390.Models
{
    public class LogIn 
    {
        public string ID {get; set;}
        [Required]
        [Display(Name="User Name")]
        public string userName { get; set; }
        
    }
}