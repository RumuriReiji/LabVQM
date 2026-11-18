using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VuQuangMinh231230843.Models;

public partial class TheLoai
{
    [Key]
    public int MaTl { get; set; }

    public string TenTl { get; set; } = null!;

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
