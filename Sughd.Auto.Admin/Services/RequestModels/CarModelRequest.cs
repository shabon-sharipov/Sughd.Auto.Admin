﻿using System.ComponentModel.DataAnnotations;

namespace Sughd.Auto.Admin.Services.RequestModels;

public class CarModelRequest
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide Name")]
    public string Name { get; set; } = string.Empty;
    
    public long MarkaId { get; set; }
}