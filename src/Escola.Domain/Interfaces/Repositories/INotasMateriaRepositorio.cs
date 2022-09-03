﻿using Escola.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface INotasMateriaRepositorio
    {
        public NotasMateria ObterPorId(Guid id);
        public void Inserir(NotasMateria notasMateria);
        public void Excluir(NotasMateria notasMateria);
        public void Alterar(NotasMateria notasMateria);
    }
}