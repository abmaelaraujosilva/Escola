using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escola.Models
{
    public class Membro
    {
        public int IdMembro { get; set; }

        public int IdProjeto { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Curso")]
        public string Curso { get; set; }

        public string Tipo { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Endereço no Lattes")]
        public string EnderecoNoLattes { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Titulação")]
        public string Titulacao { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Instituição")]
        public string Instituicao { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Função")]
        public string Funcao { get; set; }
    }
}