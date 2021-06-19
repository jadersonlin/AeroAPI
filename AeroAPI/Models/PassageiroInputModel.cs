using System.ComponentModel.DataAnnotations;

namespace AeroAPI.Models
{
    /// <summary>
    /// Passageiro
    /// </summary>
    public class PassageiroInputModel
    {
        /// <summary>
        /// Nome do passageiro
        /// </summary>
        [Required(ErrorMessage = "Nome inválido!")]
        public string Nome { get; set; }

        /// <summary>
        /// Idade do passageiro
        /// </summary>
        [Required(ErrorMessage = "Idade inválida!")]
        public int Idade { get; set; }

        /// <summary>
        /// Celular do passageiro
        /// </summary>
        [Required]
        [Phone(ErrorMessage = "Celular inválido!")]
        public string Celular { get; set; }
    }
}
