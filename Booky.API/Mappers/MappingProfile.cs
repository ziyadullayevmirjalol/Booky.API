using AutoMapper;
using Booky.API.Models.Author;
using Booky.API.Models.Book;
using Booky.API.Models.Publisher;
using Booky.API.Models.Review;
using Booky.Domain.Entities;

namespace Booky.API.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorCreateModel>().ReverseMap();
        CreateMap<Author, AuthorUpdateModel>().ReverseMap();
        CreateMap<Author, AuthorViewModel>().ReverseMap();

        CreateMap<Book, BookCreateModel>().ReverseMap();
        CreateMap<Book, BookUpdateModel>().ReverseMap();
        CreateMap<Book, BookViewModel>().ReverseMap();


        CreateMap<Publisher, PublisherCreateModel>().ReverseMap();
        CreateMap<Publisher, PublisherUpdateModel>().ReverseMap();
        CreateMap<Publisher, PublisherViewModel>().ReverseMap();

        CreateMap<Review, ReviewCreateModel>().ReverseMap();
        CreateMap<Review, ReviewUpdateModel>().ReverseMap();
        CreateMap<Review, ReviewViewModel>().ReverseMap();
    }
}
