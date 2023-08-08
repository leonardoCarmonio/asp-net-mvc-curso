﻿using DL.CursoMvc.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.CursoMvc.Domain.Interfaces
{
    public interface IClienteRepository : IRepositoryRead<Cliente>, IRepositoryWrite<Cliente>
    {
        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> ObterAtivos();
    }
}
