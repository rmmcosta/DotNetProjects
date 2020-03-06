﻿using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
