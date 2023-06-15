﻿using EntityLayer.Abstract;

namespace EntityLayer.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
    }
}
