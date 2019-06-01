using Escola.Models;
using Escola.Repository.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escola.Repository.Model
{
    public class MembroRepository : IRepository<Membro>
    {
        private IConnection Db = new MySqlDB();
        private MapperBase<Membro> Mapper = new MembroMapper();
        public bool ADD(Membro TItem)
        {
            return Db.ExeculteNonQuery("INSERT INTO membro(Id_Membro, Id_Projeto, CPF_Matricula, Nome, Telefone, Email, Curso, Tipo, Endereco_no_Lattes, Titulacao, Instituicao_Pertence, Funcao) " +
                "VALUES(DEFAULT," + TItem.IdProjeto + ",'" + TItem.CPF + "','" + TItem.Nome + "','" + TItem.Telefone + "','" + TItem.Email + "','" + TItem.Curso + "','" + TItem.Tipo + "','" + 
                TItem.EnderecoNoLattes + "','" + TItem.Titulacao + "','" + TItem.Instituicao + "','" + TItem.Funcao + "')");
        }

        public bool DELETE(Membro TItem)
        {
            return Db.ExeculteNonQuery("DELETE FROM membro WHERE Id_Membro = " + TItem.IdMembro);
        }

        public Membro GETBYID(int ID)
        {
            return Mapper.MapperAllFromDataSource(Db.List("SELECT * FROM membro WHERE Id_membro = " + ID)).First();
        }

        public List<Membro> GETBYIDPROJ(int ID, string Where)
        {
            return Mapper.MapperAllFromDataSource(Db.List("SELECT * FROM membro WHERE Id_Projeto = " + ID + " AND " + Where));
        }

        public List<Membro> LISTAR()
        {
            return Mapper.MapperAllFromDataSource(Db.List("SELECT * FROM membro"));
        }

        public bool UPDATE(Membro TItem, int ID)
        {
            return Db.ExeculteNonQuery("UPDATE membro SET CPF_Matricula = '" + TItem.CPF+"', Nome = '"+ TItem.Nome + "', Telefone = '"+ TItem.Telefone + "', Email = '"+ TItem.Email + "', Curso = '"+ TItem.Curso + 
                "', Tipo = '"+ TItem.Tipo + "', Endereco_no_Lattes = '"+ TItem.EnderecoNoLattes + "', Titulacao = '"+ TItem.Titulacao + "', Instituicao_Pertence = '"+ TItem.Instituicao + "', Funcao = '"+ TItem.Funcao +"' WHERE Id_Membro = " + ID);
        }
    }
}