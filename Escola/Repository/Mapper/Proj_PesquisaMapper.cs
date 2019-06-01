using Escola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Escola.Repository.Mapper
{
    public class Proj_PesquisaMapper : MapperBase<Proj_Pesquisa>
    {
        public override Proj_Pesquisa MapperFromDataSource(DataRow DR)
        {
            return new Proj_Pesquisa()
            {
                IdProjeto = Convert.ToInt32(DR["Id_Projeto"]),
                NomeProjeto = DR["Nome_Projeto"].ToString(),
                ModalidadeExecucao = DR["Modalidade_Execucao"].ToString(),
                LinhaPesquisa = DR["Linha_Pesquisa"].ToString(),
                AreaConhecimento = DR["Area_Conhecimento"].ToString(),
                LocalExecucao = DR["Local_Execucao"].ToString(),
                InicioProj = Convert.ToDateTime(DR["Inicio_Projeto"]).Date,
                FimProj = Convert.ToDateTime(DR["Fim_Projeto"]).Date,
                DataSubmissao = Convert.ToDateTime(DR["Data_Submissao"]),
                PublicoAlvo = DR["Publico_Alvo"].ToString(),
                Resumo = DR["Resumo"].ToString(),
                Delimitacao = DR["Delimitacao"].ToString(),
                Justificativa = DR["Justificativa"].ToString(),
                ProblemaPesquisa = DR["Problema_Pesquisa"].ToString(),
                ObjetivoGeral = DR["Objetivo_Geral"].ToString(),
                ObjetivosEspecificos = DR["Objetivos_Especificos"].ToString(),
                ReferencialTeorico = DR["Referencial_Teorico"].ToString(),
                Metodologia = DR["Metodologia"].ToString(),
                ResultadosEsperados = DR["Resultados_Esperados"].ToString(),
                Infraestrutura = DR["Infraestrutura"].ToString(),
                ReferenciaBibliografica = DR["Referencia_Bibliografica"].ToString(),
                IdUsuario = Convert.ToInt32(DR["Id_Usuario"]),
                Status = DR["Status"].ToString()
            };
        }
    }
}