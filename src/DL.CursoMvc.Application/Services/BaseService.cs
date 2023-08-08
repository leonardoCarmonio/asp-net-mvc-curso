using DL.CursoMvc.Infra.Data.UoW;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.CursoMvc.Application.Services
{
    public abstract class BaseService
    {
        private readonly IUnitOfWork _uow;
        protected ValidationResult ValidacaoProcesso = new ValidationResult();

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void AdicionarResultadoProcessamento(ValidationResult validationResult)
        {
            ValidacaoProcesso.Add(validationResult);
        }

        protected bool Commit()
        {
            return _uow.Commit();
        }
    }
}
