using Escola.Models;
using Escola.Repository.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escola.Repository.Model
{
    public class Proj_PesquisaRepository : IRepository<Proj_Pesquisa>
    {
        private IConnection Db = new MySqlDB();
        private MapperBase<Proj_Pesquisa> Mapper = new Proj_PesquisaMapper();
        public bool ADD(Proj_Pesquisa TItem)
        {
            return Db.ExeculteNonQuery("INSERT INTO projeto_pesquisa(Id_Projeto, Nome_Projeto, Modalidade_Execucao, Linha_Pesquisa, Area_Conhecimento, Local_Execucao, Inicio_Projeto, Fim_Projeto, Data_Submissao, Publico_Alvo, Resumo, Delimitacao, Justificativa, Problema_Pesquisa, Objetivo_Geral, Objetivos_Especificos, Referencial_Teorico, Metodologia, Resultados_Esperados, Infraestrutura, Referencia_Bibliografica, Id_Usuario, Status) " +
                "VALUES( DEFAULT, '" + TItem.NomeProjeto + "','" + TItem.ModalidadeExecucao + "','" + TItem.LinhaPesquisa + "','" + TItem.AreaConhecimento + "','" +
                TItem.LocalExecucao + "','" + TItem.InicioProj.ToString("yyyy-MM-dd") + "','" + TItem.FimProj.ToString("yyyy-MM-dd") + "','" + TItem.DataSubmissao.ToString("yyyy-MM-dd") + "','" +
                TItem.PublicoAlvo + "','" + TItem.Resumo + "','" + TItem.Delimitacao + "','" + TItem.Justificativa + "','" + TItem.ProblemaPesquisa + "','" + TItem.ObjetivoGeral + "','" +
                TItem.ObjetivosEspecificos + "','" + TItem.ReferencialTeorico + "','" + TItem.Metodologia + "','" + TItem.ResultadosEsperados + "','" + TItem.Infraestrutura + "','" +
                TItem.ReferenciaBibliografica + "'," + TItem.IdUsuario + ",'" + TItem.Status + "')");
        }

        public bool DELETE(Proj_Pesquisa TItem)
        {
            return Db.ExeculteNonQuery("DELETE FROM projeto_pesquisa WHERE Id_Projeto = " + TItem.IdProjeto);
        }

        public Proj_Pesquisa GETBYID(int ID)
        {
            return Mapper.MapperAllFromDataSource(Db.List("SELECT * FROM projeto_pesquisa WHERE Id_Projeto = " + ID)).First();
        }

        public List<Proj_Pesquisa> LISTAR()
        {
            return Mapper.MapperAllFromDataSource(Db.List("SELECT * FROM projeto_pesquisa"));
        }

        public bool UPDATE(Proj_Pesquisa TItem, int ID)
        {
            return Db.ExeculteNonQuery("UPDATE projeto_pesquisa SET Id_Projeto = " + TItem.IdProjeto + ", Nome_Projeto='" + TItem.NomeProjeto + "', Modalidade_Execucao = '" + TItem.ModalidadeExecucao
                + "', Linha_Pesquisa'" + TItem.LinhaPesquisa + "', Local_Execucao='" + TItem.LocalExecucao + "', Area_Conhecimento = '" + TItem.AreaConhecimento + "', Inicio_Projeto='" + TItem.InicioProj
                + "', Fim_Projeto='" + TItem.FimProj + "', Data_Submissao = '" + TItem.DataSubmissao + "', Publico_Alvo='" + TItem.PublicoAlvo + "', Resumo='" + TItem.Resumo + "', Delimitacao='" + TItem.Delimitacao
                + "', Justificativa='" + TItem.Justificativa + "', Problema_Pesquisa='" + TItem.ProblemaPesquisa + "', Objetivo_Geral='" + TItem.ObjetivoGeral + "', Objetivos_Especificos='" + TItem.ObjetivosEspecificos
                + "', Referencial_Teorico='" + TItem.ReferencialTeorico + "', Metodologia='" + TItem.Metodologia + "', Resultados_Esperados='" + TItem.ResultadosEsperados + "', Infraestrutura='" + TItem.Infraestrutura
                + "', Referencia_Bibliografica='" + TItem.ReferenciaBibliografica + "', Status = '" + TItem.Status + "' WHERE Id_Projeto = " + ID);
        }

        public List<Proj_Pesquisa> GETLAST()
        {
            return Mapper.MapperAllFromDataSource(Db.List("SELECT * FROM projeto_pesquisa WHERE Id_Projeto = (SELECT MAX(Id_Projeto) FROM projeto_pesquisa)"));
        }
    }
}