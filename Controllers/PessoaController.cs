using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projeto_base_api_net.Context;
using projeto_base_api_net.Models;

namespace projeto_base_api_net.Controllers
{
    [ApiController]
	[Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        
        private readonly PessoaContext _context;

		public PessoaController(PessoaContext context){
			_context = context;
		}

        [HttpPost]
        public IActionResult Create(Pessoa pessoa){
		
            _context.Add(pessoa);	
            _context.SaveChanges();
            return Ok(pessoa);	

	    }

        [HttpGet("{id}")]
	    public IActionResult ObterporId(int id){

            var pessoa = _context.Pessoas.Find(id);
            if(pessoa == null)
                return NotFound();

            return Ok(pessoa);
	    } 

        [HttpPut("{id}")]
	    public IActionResult AtualizarPessoa(int id, Pessoa pessoa){
		
            var pessoaBanco = _context.Pessoas.Find(id);
            if(pessoaBanco == null)
                return NotFound();

            pessoaBanco.nome = pessoa.nome;
            pessoaBanco.email = pessoa.email;
            pessoaBanco.senha = pessoa.senha;

            _context.Pessoas.Update(pessoaBanco);
            _context.SaveChanges();

            return Ok(pessoaBanco);
            
	    }

        [HttpDelete("{id}")]
	    public IActionResult Deletar(int id){
		
            var pessoaBanco = _context.Pessoas.Find(id);
            if(pessoaBanco == null)
                return NotFound();

            _context.Pessoas.Remove(pessoaBanco);
            _context.SaveChanges();		

            return NoContent();		

	    }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome){
            
            var pessoas = _context.Pessoas.Where(x => x.nome.Contains(nome));
            return Ok(pessoas);

        } 

    }
}