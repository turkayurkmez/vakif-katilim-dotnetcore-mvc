﻿using BookStore.Common.Entities;
using BookStore.Infrastructure.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public IEnumerable<Genre> GetAllGenresForMenu()
        {
            return genreRepository.GetAllWithEnumerable();
        }
    }
}
