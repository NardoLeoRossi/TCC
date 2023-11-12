using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcamentosIfc
{
    public static class Parametros
    {
        private static AppDbContext _dbContext;
        
        public static string PeriodoSinapiSelecionado;

        public static string ProjetoSelecionado;

        public static AppDbContext AppDbContext
        { 
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new AppDbContext();
                }
                return _dbContext;
            }
        }
    }
}
