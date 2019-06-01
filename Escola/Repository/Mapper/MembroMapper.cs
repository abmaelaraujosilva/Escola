using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Escola.Models;

namespace Escola.Repository.Mapper
{
    public class MembroMapper : MapperBase<Membro>
    {
        public override Membro MapperFromDataSource(DataRow DR)
        {
            return new Membro()
            {
                IdMembro = Convert.ToInt32(DR["Id_Membro"]),
                IdProjeto = Convert.ToInt32(DR["Id_Projeto"]),
                CPF = DR["CPF_Matricula"].ToString(),
                Nome = DR["Nome"].ToString(),
                Telefone = DR["Telefone"].ToString(),
                Email = DR["Email"].ToString(),
                Curso = DR["Curso"].ToString(),
                Tipo = DR["Tipo"].ToString(),
                EnderecoNoLattes = DR["Endereco_no_Lattes"].ToString(),
                Titulacao = DR["Titulacao"].ToString(),
                Instituicao = DR["Instituicao_Pertence"].ToString(),
                Funcao = DR["Funcao"].ToString()
            };
        }
    }
}