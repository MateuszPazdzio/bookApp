﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookApp.Models
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
