using product.API.Models;
using System.ComponentModel.DataAnnotations;

namespace product.API.Models;

public class Usuario : Persona
{
    public Usuario(string ci, string nombre, string apellido, DateTime fechaNacimiento, double salarioPromedio) : base(ci,nombre,apellido,fechaNacimiento)
    {
        SalarioPromedio = salarioPromedio;
    }
    
    public double SalarioPromedio { get; set; }
    public List<Cuenta>? Cuentas { get; set; }
}
