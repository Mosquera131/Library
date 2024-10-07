using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLibrary.Data;
using NewLibrary.Models;
using NewLibrary.Repositories;

namespace NewLibrary.Services
{
    public class BookServices : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetById(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task Add(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var book = await GetById(id);

            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                return true;
            }
            Console.WriteLine("The Book was not found");
            return false;
        }

        public async Task<bool> CheckById(int id)
        {
            return await _context.Books.AnyAsync(v => v.Id == id);
        }


        public async Task<IEnumerable<Book>> SearchKeyWord(string keyword)

        {

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await GetAll();
            }
            return await _context.Books.Where(w => w.Name.Contains(keyword)).ToListAsync();
        }

        public async Task<bool> CheckExistence(int id)
        {
            try
            {
                return await _context.Books.AnyAsync(v => v.Id == id);
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Error al agregar el vehículo a la base de datos.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al agregar el vehículo.", ex);
            }

        }

    }
}
