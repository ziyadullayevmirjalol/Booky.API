using Booky.API.Middlewares;
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


    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddTransient<UserCreateModelValidator>();
        services.AddTransient<UserUpdateModelValidator>();
        services.AddTransient<UserChangePasswordModelValidator>();
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
