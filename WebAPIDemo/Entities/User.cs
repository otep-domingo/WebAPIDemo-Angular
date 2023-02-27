using System;
using System.Collections.Generic;

namespace WebAPIDemo.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Userame { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }
}
