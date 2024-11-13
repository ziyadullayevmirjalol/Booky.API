using AutoMapper;
using Booky.Domain.Entities;
using Booky.Domain.Models.Author;
using Booky.Domain.Models.Book;
using Booky.Domain.Models.Publisher;
using Booky.Domain.Models.Review;

namespace Booky.Service.Mappers;

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
