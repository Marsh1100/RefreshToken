using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Dtos;

public class DatosUserDto
{
    [Required]
    public string Message { get; set; }
    [Required]
    public bool IsAuthenticated { get; set; }

    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }

     [Required]
    public List<string> Roles { get; set; }
    [Required]
    public string  Token{ get; set; }

    
    [JsonIgnore] // ->this attribute restricts the property to be shown in the result
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }   

}
