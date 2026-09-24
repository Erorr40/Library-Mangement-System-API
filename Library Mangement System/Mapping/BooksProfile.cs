using AutoMapper;
using Library_Mangement_System.DTOs.BooksDTOs;
using Library_Mangement_System.Models;

namespace Library_Mangement_System.Mapping
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BooksDTO>().ReverseMap();
            CreateMap<Book, CreateBooksDTO>().ReverseMap();
            CreateMap<Book, UpdateBooksDTO>().ReverseMap();
        }
    }
}
