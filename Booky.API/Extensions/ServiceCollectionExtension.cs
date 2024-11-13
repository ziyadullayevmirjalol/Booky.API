using Booky.API.ApiService.Authors;
using Booky.API.ApiService.Books;
using Booky.API.ApiService.Publishers;
using Booky.API.ApiService.Reviews;
using Booky.API.Middlewares;
using Booky.API.Validators.Authors;
using Booky.API.Validators.Books;
using Booky.API.Validators.Publishers;
using Booky.API.Validators.Reviiews;
using Booky.DataAccess.UnitOfWorks;
using Booky.Service.Services.Authors;
using Booky.Service.Services.Books;
using Booky.Service.Services.Publishers;
using Booky.Service.Services.Reviews;

namespace Booky.API.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IPublisherService, PublisherService>();
        services.AddScoped<IReviewService, ReviewService>();
    }

    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorApiService, AuthorApiService>();
        services.AddScoped<IBookApiService, BookApiService>();
        services.AddScoped<IPublisherApiServce, PublisherApiService>();
        services.AddScoped<IReviewApiService, ReviewApiService>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddTransient<AuthorCreateModelValidator>();
        services.AddTransient<AuthorUpdateModelValidator>();

        services.AddTransient<BookUpdateModelValidator>();
        services.AddTransient<BookCreateModelValidator>();

        services.AddTransient<PublisherUpdateModelValidator>();
        services.AddTransient<PublisherCreateModelValidator>();

        services.AddTransient<ReviewCreateModelValidator>();
        services.AddTransient<ReviewUpdateModelValidator>();
    }

    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<AlreadyExistExceptionHandler>();
        services.AddExceptionHandler<ArgumentIsNotValidExceptionHandler>();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddExceptionHandler<InternalServerExceptionHandler>();
    }
}
