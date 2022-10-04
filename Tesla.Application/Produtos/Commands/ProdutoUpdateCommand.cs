using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Application.Produtos.Commands
{
    public class ProdutoUpdateCommand : ProdutoCommand
    {
        public int Id { get; set; }
    }
}
