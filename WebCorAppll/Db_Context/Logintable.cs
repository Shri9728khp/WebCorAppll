using System;
using System.Collections.Generic;

#nullable disable

namespace WebCorAppll.DB_Context
{
    public partial class Logintable
    {
        public int Id { get; set; }
        public string Nmae { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
