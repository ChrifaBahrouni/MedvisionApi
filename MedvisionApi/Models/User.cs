using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedvisionApi.Models;

public partial class User
{
    public int? Id { get; set; }

    public string? Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    [Url(ErrorMessage =" url must be valide ")]
    public string? PhotoUrl { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Phone { get; set; } = null!;

 

    public virtual ICollection<Commentaire>? Commentaires { get; set; } = new List<Commentaire>();

    public virtual ICollection<Notification>? Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Post>? Posts { get; set; } = new List<Post>();
}
