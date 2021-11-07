using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;




namespace Livraria_da_Lua.Classes
{
    class Prod_Livros
    {
        //Classes onde representa 1 livro
        public class Unit
        {
            //Regras para cadatro de livros e validação/Teste
            [Required(ErrorMessage = "ISBN é obrigatório")]
            [StringLength(17, MinimumLength = 17, ErrorMessage = "ISBN do livro deve ter 13 digitos.")]
            public string Isbn { get; set; }

            [Required(ErrorMessage = "Título do livro é obrigatório")]
            [StringLength(50, ErrorMessage = "Título do livro deve ter no máximo 50 caracteres.")]
            public string Titulo { get; set; }

            [Required(ErrorMessage = "Sub Título é obrigatório")]
            [StringLength(50, ErrorMessage = "Sub Título deve ter 50 digitos.")]
            public string SubTitulo { get; set; }

            [Required(ErrorMessage = "Série/Coleção é obrigatório")]
            [StringLength(20, ErrorMessage = "Série/Coleção deve ter 20 digitos.")]
            public string Serie { get; set; }

            [Required(ErrorMessage = "Volume é obrigatório")]
            [StringLength(10, ErrorMessage = "Volume deve ter 10 digitos.")]
            public string Volume { get; set; }

            [Required(ErrorMessage = "Gênero do livro é obrigatório")]
            [StringLength(15, ErrorMessage = "Gênero do livro deve ter 15 digitos.")]
            public string Genero { get; set; }

            [Required(ErrorMessage = "Editora é obrigatório")]
            [StringLength(20, ErrorMessage = "Editora deve ter 20 digitos.")]
            public string Editora { get; set; }

            [Required(ErrorMessage = "Autor do livro é obrigatório")]
            [StringLength(50, ErrorMessage = "Autor do livro deve ter 50 digitos.")]
            public string Autor { get; set; }

            [StringLength(50, ErrorMessage = "Tradutor do livro deve ter 50 digitos.")]
            public string Tradutor { get; set; }

            [Required(ErrorMessage = "Idioma do livro é obrigatório")]
            [StringLength(10, ErrorMessage = "Idioma deve ter 10 digitos.")]
            public string Idioma { get; set; }

            [Required(ErrorMessage = "Edição do livro é obrigatório")]
            [StringLength(5, ErrorMessage = "Edição deve ter 5 digitos.")]
            public string Edicao { get; set; }

            [Required(ErrorMessage = "Ano do livro é obrigatório")]
            [RegularExpression("([0-9]+)", ErrorMessage = "Ano só aceita valores numéricos.")]
            [StringLength(4, MinimumLength = 4, ErrorMessage = "Ano do livro deve ter 4 digitos.")]
            public string Ano { get; set; }

            [Required(ErrorMessage = "Quantidade de páginas do livro é obrigatório")]
            [StringLength(11, ErrorMessage = "Quantidade de páginas do livro deve ter 11 digitos.")]
            public string Paginas { get; set; }

            [Required(ErrorMessage = "Descrição do livro é obrigatório")]
            //[StringLength(120, MinimumLength = 120, ErrorMessage = "Descrição do livro deve ter 120 digitos.")]
            public string Descricao { get; set; }


            public void validaClasse()
            {
                //Teste de validação dos dados do livro conforme as regras estipuladas acima
                ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
                List<ValidationResult> results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(this, context, results, true);

                if (isValid == false)
                {
                    StringBuilder sbrErrors = new StringBuilder();
                    foreach (var validationResult in results)
                    {
                        sbrErrors.AppendLine(validationResult.ErrorMessage);
                    }
                    throw new ValidationException(sbrErrors.ToString());
                }
            }



           /*#region "CRUD do Fichario DB SQL Server"


            #endregion*/

        }

        //Classe onde contém o grupo de livros
        public class List
        {
            public List<Unit> ListUnit { get; set; }
        }

    }
}
