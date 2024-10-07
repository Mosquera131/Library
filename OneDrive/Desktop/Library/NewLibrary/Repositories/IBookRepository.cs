using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewLibrary.Models;
using NewLibrary.Services;

namespace NewLibrary.Repositories;

public interface IBookRepository
{
    Task<bool> Delete(int id); //done. 
    Task<IEnumerable<Book>> GetAll();
    Task<Book?> GetById(int id);
    Task<bool> CheckById(int id);
    Task Add(Book book);
    Task Update(Book book);
    Task<IEnumerable<Book>> SearchKeyWord(string keyword);

    Task<bool> CheckExistence (int Id);

    
    
        
    

    
}
