﻿using Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string Password { get; set; }        
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
