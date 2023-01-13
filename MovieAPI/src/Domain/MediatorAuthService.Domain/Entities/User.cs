﻿using MovieAPI.Domain.Core.Base.Concrete;
using MovieAPI.Domain.Core.Base.Abstract;

namespace MovieAPI.Domain.Entities;

public class User : BaseEntity, IEntity
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string RefreshToken { get; set; }
}