using System.ComponentModel.DataAnnotations;

namespace product.Models
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
    }
}
