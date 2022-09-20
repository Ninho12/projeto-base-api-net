using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projeto_base_api_net.Models;
using System.Data;

namespace projeto_base_api_net.Context
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options){}
        
		public DbSet<Pessoa> Pessoas { get; set; }

    }
}