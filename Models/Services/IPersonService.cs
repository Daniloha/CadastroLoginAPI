using System;
using System.Collections.Generic;
using APICadastro.Models;


namespace APICadastro.Models.Services
{
    public interface IPersonService
    {
        Pessoa Create(Pessoa pessoa);
        Pessoa FindByID(long id);
        Pessoa Update(Pessoa pessoa);
        void Delete(long id);
        List<Pessoa> FindAll();


    }
}