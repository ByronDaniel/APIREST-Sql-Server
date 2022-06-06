using System.ComponentModel.DataAnnotations;

namespace BP.Models;

public class Usuario
{
    public Usuario(string ci, string nombre, string apellido, DateTime fechaNacimiento, double salarioPromedio)
    {
        Ci = ci;
        Nombre = nombre;
        Apellido = apellido;
        FechaNacimiento = fechaNacimiento;
        SalarioPromedio = salarioPromedio;
    }
    [Key]
    public string Ci { get; set; }

    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public double SalarioPromedio { get; set; }
}
