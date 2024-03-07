using AutoMapper;
using BookStore.Common.Entities;
using BookStore.Services.DataTransferObjects.Requests;
using BookStore.Services.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.MappingProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateNewBookRequest, Book>();
            CreateMap<Book, BookForAddToCard>();
            CreateMap<UpdateBookRequest, Book>().ReverseMap();
        }
    }
}
