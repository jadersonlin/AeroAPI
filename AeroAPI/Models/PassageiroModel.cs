using System.ComponentModel.DataAnnotations;

namespace AeroAPI.Models
{
    /// <summary>
    /// Passageiro
    /// </summary>
    public class PassageiroModel
    {
        /// <summary>
        /// Identificador de passageiro
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Nome dod passageiro
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Idade do passageiro
        /// </summary>
        [Required]
        public int Idade { get; set; }

        /// <summary>
        /// Celular do passageiro
        /// </summary>
        [Required]
        [Phone(ErrorMessage = "Celular inválido!")]
        public string Celular { get; set; }
    }
}
