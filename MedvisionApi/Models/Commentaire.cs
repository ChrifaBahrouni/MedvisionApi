using System;
using System.Collections.Generic;

namespace MedvisionApi.Models;

public partial class Commentaire
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Content { get; set; } = null!;

    public string Time { get; set; } = null!;

    public int PostId { get; set; }

    public virtual Post? Post { get; set; } = null!;

    public virtual User? User { get; set; } = null!;
}
