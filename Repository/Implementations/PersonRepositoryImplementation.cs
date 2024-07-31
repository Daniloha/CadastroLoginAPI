using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICadastro.Models.Context;
using Microsoft.EntityFrameworkCore;
using APICadastro.Repository;
using APICadastro.Models;

namespace APICadastro.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        // = new MySQLContext();
        
        private MySQLContext _context;

        public PersonRepositoryImplementation( MySQLContext context)
        {
            _context = context;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            try
            {
                _context.Add(pessoa);
                _context.SaveChanges();
            }catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return pessoa;
        }

        public void Delete(long id)
        {
            var result = _context.Pessoas.SingleOrDefault(p => p.ID.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Pessoas.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            
        }

        public List<Pessoa> FindAll()
        {
      
            return _context.Pessoas.ToList();
        }

        



        public Pessoa FindByID(long id)
        {
            return _context.Pessoas.SingleOrDefault(p => p.ID.Equals(id));

        }

        public Pessoa Update(Pessoa pessoa)
        { 
            if (!Exists(pessoa.ID)) return new Pessoa(); 
            var result = _context.Pessoas.SingleOrDefault(p => p.ID.Equals(pessoa.ID)); 
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(pessoa);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }         
            return pessoa;
        }

        public bool Exists(long iD)
        {
            return _context.Pessoas.Any(p => p.ID.Equals(iD));
        }
    }
}