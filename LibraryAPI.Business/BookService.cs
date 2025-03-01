﻿using LibraryAPI.Business.Interfaces;
using LibraryAPI.Data.Repository;
using LibraryAPI.Models.Domain;

namespace LibraryAPI.Business
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookWithId> AddBookAsync(BookWithId book)
        {
            return await _bookRepository.AddAsync(book);
        }

        public async Task<List<BookWithId>> GetAllBooksAsync(string searchString = "", string sortBy = "id", int offset = 0, int setLimit = 10)
        {
            
            return await _bookRepository.GetAllAsync(searchString, sortBy, offset, setLimit);
        }

        public async Task<BookWithId?> GetBookAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<BookWithId> UpdateBookAsync(BookWithId book)
        {
            await _bookRepository.UpdateAsync(book);
            return book;
        }
    }
}
