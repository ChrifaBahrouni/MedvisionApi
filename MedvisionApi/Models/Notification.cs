using System;
using System.Collections.Generic;

namespace MedvisionApi.Models;

public partial class Notification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Content { get; set; } = null!;

    public virtual User? User { get; set; } 
}
