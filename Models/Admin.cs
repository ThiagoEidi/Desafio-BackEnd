using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_BackEnd.Models
{
    public class Admin : User
    {
        public string Role { get; set; } = "Admin";
    }
}