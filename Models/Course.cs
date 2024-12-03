using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_2.Models;

public partial class Course
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    public string Crs_name { get; set; }

    [StringLength(150)]
    public string Crs_desc { get; set; }

    public int? Duration { get; set; }
}
