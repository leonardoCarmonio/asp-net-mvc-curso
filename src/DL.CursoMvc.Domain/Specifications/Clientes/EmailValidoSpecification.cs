﻿using DL.CursoMvc.Domain.Models;
using DL.CursoMvc.Domain.ValueObjects;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.CursoMvc.Domain.Specifications.Clientes
{
    public class EmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return Email.Validar(cliente.Email);
        }
    }
}
