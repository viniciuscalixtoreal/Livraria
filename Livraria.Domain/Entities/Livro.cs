using Livraria.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Domain.Entities
{
    public sealed class Livro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Título do Livro.")]
        [StringLength(150)]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "Informe o Autor do Livro.")]
        [StringLength(200)]
        public string? Autor { get; set; }

        [Required(ErrorMessage = "Informe a Data de Lançamento do Livro.")]
        public DateTime Lancamento { get; set; }

        [Required(ErrorMessage = "Informe a Capa do Livro.")]
        [StringLength(200)]
        public string? Capa { get; set; }

        [Required]
        [EnumDataType(typeof(Editora), ErrorMessage = "Selecione a Editora.")]
        public Editora Editora { get; set; }

        [Required]
        [EnumDataType(typeof(Categoria), ErrorMessage = "Selecione a Categoria.")]
        public Categoria Categoria { get; set; }

        public Livro(int id, string? titulo, string? autor, DateTime lancamento, string? capa, Editora editora, Categoria categoria)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Lancamento = lancamento;
            Capa = capa;
            Editora = editora;
            Categoria = categoria;
        }
    }
}
