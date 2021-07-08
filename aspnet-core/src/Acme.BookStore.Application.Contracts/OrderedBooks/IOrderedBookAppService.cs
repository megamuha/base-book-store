using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.OrderedBooks
{
    public interface IOrderedBookAppService
        
    {
        Task<OrderedBookDto> GetAsync(Guid id);

        Task<PagedResultDto<OrderedBookDto>> GetListAsync(GetOrderedBookListDto input);

        Task<PagedResultDto<OrderedBookDto>> GetClientListAsync(GetOrderedBookListDto input);

        Task<OrderedBookDto> CreateAsync(CreateUpdateOrderedBookDto input);

        Task UpdateAsync(Guid id, CreateUpdateOrderedBookDto input);

        Task DeleteAsync(Guid id);
    }
}