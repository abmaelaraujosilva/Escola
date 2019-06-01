using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escola.Models
{
    public class Proj_Pesquisa
    {
        public int IdProjeto { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Nome do Projeto")]
        public string NomeProjeto { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Modalidade de Execução")]
        public string ModalidadeExecucao { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Linha de Pesquisa")]
        public string LinhaPesquisa { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Area do Conhecimento")]
        public string AreaConhecimento { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Local de Execução")]
        public string LocalExecucao { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Data de Inicio do Projeto")]
        [DataType(DataType.Date)]
        public DateTime InicioProj { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Data de Término do Projeto")]
        [DataType(DataType.Date)]
        public DateTime FimProj { get; set; }

        public DateTime DataSubmissao { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Público Alvo")]
        public string PublicoAlvo { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Resumo")]
        public string Resumo { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Delimitação")]
        public string Delimitacao { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Justificativa")]
        public string Justificativa { get; set; }

        [Required(ErrorMessage = "Informe os {0}")]
        [Display(Name = "Problemas")]
        public string ProblemaPesquisa { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Objetivo Geral")]
        public string ObjetivoGeral { get; set; }

        [Required(ErrorMessage = "Informe os {0}")]
        [Display(Name = "Objetivos Específicos")]
        public string ObjetivosEspecificos { get; set; }

        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Referencial Teórico")]
        public string ReferencialTeorico { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Metodologia")]
        public string Metodologia { get; set; }

        [Required(ErrorMessage = "Informe os {0}")]
        [Display(Name = "Resultados Esperados")]
        public string ResultadosEsperados { get; set; }

        [Required(ErrorMessage = "Informe a {0}")]
        [Display(Name = "Infraestrutura")]
        public string Infraestrutura { get; set; }

        [Required(ErrorMessage = "Informe as {0}")]
        [Display(Name = "Referências Bibliográficas")]
        public string ReferenciaBibliografica { get; set; }

        public int IdUsuario { get; set; }

        public string Status { get; set; }
    }
}