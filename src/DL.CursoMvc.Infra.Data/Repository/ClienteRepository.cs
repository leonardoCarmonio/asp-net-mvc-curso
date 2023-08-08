using Dapper;
using DL.CursoMvc.Domain.Interfaces;
using DL.CursoMvc.Domain.Models;
using DL.CursoMvc.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.CursoMvc.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CursoMvcContext context) : base(context) { }
       
        public IEnumerable<Cliente> ObterAtivos()
        {
            //return Buscar(c => c.Ativo && !c.Excluido);
            string sql = @"SELECT *
                           FROM Clientes c
                           WHERE c.Excluido = 0 
                           AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente>(sql);
        }

        public override Cliente ObterPorId(Guid id)
        {
            //throw new Exception();

            string sql = @"SELECT * 
                           FROM Clientes c 
                           LEFT JOIN Enderecos e ON c.Id = e.ClienteId
                           WHERE c.Id = @uid AND c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql: sql,
                   map: (c, e) =>
                    {
                        c.AdicionarEndereco(e);
                        return c;
                    }, param: new { uid = id }).FirstOrDefault();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.DefinirComoExcluido();

            Atualizar(cliente);
        }
    }
}
