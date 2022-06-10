using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace product.API.Models
{
    public class Cuenta
    {
        public Cuenta(string numero, string ciUsuario, char tipo, double saldo)
        {
            Numero = numero;
            CiUsuario = ciUsuario;
            Tipo = tipo;
            Saldo = saldo;
        }
        [Key]
        public string Numero { get; set; }

        public string CiUsuario { get; set; }
        public char Tipo { get; set; }
        public double Saldo { get; set; }
        [ForeignKey("CiUsuario")]
        public Usuario Usuario { get; set; }
    }
}
