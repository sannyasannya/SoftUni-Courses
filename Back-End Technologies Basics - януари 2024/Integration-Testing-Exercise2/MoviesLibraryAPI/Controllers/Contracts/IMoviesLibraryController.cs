﻿using MoviesLibraryAPI.Data.Models;

namespace MoviesLibraryAPI.Controllers.Contracts
{
    public interface IMoviesLibraryController
    {
        Task AddAsync(Movie movie);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByTitle(string title);
        Task<IEnumerable<Movie>> SearchByTitleAsync(string titleFragment);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(string title);
        Task SearchByTitleFragmentAsync(string v);
    }
}
