using DL.CursoMvc.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.CursoMvc.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CursoMvcContext _context;

        public UnitOfWork(CursoMvcContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
           return _context.SaveChanges() > 0;
        }
    }
}
