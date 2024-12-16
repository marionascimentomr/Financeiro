using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay.Domain.Moldes
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public decimal ValorLimite { get; set; }
    }
}
