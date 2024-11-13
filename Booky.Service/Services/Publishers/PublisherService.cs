using AutoMapper;
using Booky.DataAccess.UnitOfWorks;
using Booky.Domain.Entities;
using Booky.Domain.Models.Publisher;
using Booky.Service.Exceptions;

namespace Booky.Service.Services.Publishers;

public class PublisherService(IUnitOfWork unitOfWork, IMapper mapper) : IPublisherService
{
    public async ValueTask<PublisherViewModel> CreateAsync(PublisherCreateModel publisher)
    {
        var existPublisher = await unitOfWork.Publishers.SelectAsync(
            expression: p => p.Name == publisher.Name && !p.IsDeleted);

        if (existPublisher is not null)
            throw new AlreadyExistException("Publisher is already exists");

        var created = await unitOfWork.Publishers.InsertAsync(mapper.Map<Publisher>(publisher));
        await unitOfWork.SaveAsync();

        return mapper.Map<PublisherViewModel>(created);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existPublisher = await unitOfWork.Publishers.SelectAsync(
            expression: p => p.Id == id && !p.IsDeleted)
            ?? throw new NotFoundException("Publisher is not found!");

        await unitOfWork.Publishers.DeleteAsync(existPublisher);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<PublisherViewModel>> GetAllAsync()
    {
        var Publishers = await unitOfWork.Publishers.SelectAsEnumerableAsync(
            expression: p => !p.IsDeleted);

        return mapper.Map<IEnumerable<PublisherViewModel>>(Publishers);
    }

    public async ValueTask<PublisherViewModel> GetByIdAsync(long id)
    {
        var existPublisher = await unitOfWork.Publishers.SelectAsync(
            expression: p => p.Id == id && !p.IsDeleted)
            ?? throw new NotFoundException("Publisher is not found!");

        return mapper.Map<PublisherViewModel>(existPublisher);
    }

    public async ValueTask<PublisherViewModel> UpdateAsync(long id, PublisherUpdateModel publisher)
    {
        var existPublisher = await unitOfWork.Publishers.SelectAsync(
            expression: p => p.Id == id && !p.IsDeleted)
            ?? throw new NotFoundException("Publisher is not found!");

        if (publisher.Address != "" || publisher.Address is not null)
            existPublisher.Address = publisher.Address;

        if (publisher.Name != "" || publisher.Name is not null)
            existPublisher.Name = publisher.Name;

        if (publisher.ContactNumber != "" || publisher.ContactNumber is not null)
            existPublisher.ContactNumber = publisher.ContactNumber;

        existPublisher.UpdatedAt = DateTime.UtcNow;

        var updated = await unitOfWork.Publishers.UpdateAsync(existPublisher);
        await unitOfWork.SaveAsync();
        return mapper.Map<PublisherViewModel>(updated);
    }
}
