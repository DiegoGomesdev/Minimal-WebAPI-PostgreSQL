﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI_Equipamentos.Models
{
    public class Equipment_model
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

    }
}
