using Acme.BookStore.Books;
using Acme.BookStore.Orders;
using Acme.BookStore.Permissions;
using Acme.BookStore.Users;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Acme.BookStore.OrderedBooks
{
    public class OrderedBookAppService : BookStoreAppService, IOrderedBookAppService, ITransientDependency

    {
        private readonly ICurrentUser _currentUser;
        private readonly IOrderedBookRepository _orderedBookRepository;
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<AppUser, Guid> _userRepository;


        public OrderedBookAppService(ICurrentUser currentUser, IOrderedBookRepository orderedBooksRepository,
             IRepository<Book, Guid> bookRepository, IRepository<AppUser, Guid> userRepository)
        {
            _currentUser = currentUser;
            _orderedBookRepository = orderedBooksRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;

        }


        
        public async Task<OrderedBookDto> CreateAsync(CreateUpdateOrderedBookDto input)
        {
            var orders = await _orderedBookRepository.CreateUsedbookAsync();       

            var currentBook = input.BookId;
            bool isBook = false;
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].BookId == currentBook)
                {
                    isBook = true;
                    break;
                }
            }

            if (isBook == false)
            {
                var order = new OrderedBook
                {
                    ClientId = (Guid)_currentUser.Id,
                    BookId = input.BookId
                };

                await _orderedBookRepository.InsertAsync(order);

                return ObjectMapper.Map<OrderedBook, OrderedBookDto>(order);
            }
            else
                throw new UserFriendlyException(L["YouHaveThisBook"]);
        }

        [Authorize(BookStorePermissions.OrderedBooks.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _orderedBookRepository.DeleteAsync(id);
        }

        public async Task<OrderedBookDto> GetAsync(Guid id)
        {
            var order = await _orderedBookRepository.GetAsync(id);

            var user = await _userRepository.GetAsync(order.ClientId);
            var book = await _bookRepository.GetAsync(order.BookId);

            var bookOrderDto = ObjectMapper.Map<OrderedBook, OrderedBookDto>(order);
            bookOrderDto.ClientName = user.UserName;
            bookOrderDto.BookName = book.Name;

            return ObjectMapper.Map<OrderedBook, OrderedBookDto>(order, bookOrderDto);
        }

       [Authorize(BookStorePermissions.OrderedBooks.ChangeStatus)]
        public async Task UpdateStatusAsync(Guid id)
        {
            var order = await _orderedBookRepository.GetAsync(id);

            order.Status = order.Status == false ? true : false;

            await _orderedBookRepository.UpdateAsync(order);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateOrderedBookDto input)
        {
            var order = await _orderedBookRepository.GetAsync(id);

            await _orderedBookRepository.UpdateAsync(order);
        }

        [Authorize(BookStorePermissions.OrderedBooks.ShowOrders)]
        public async Task<PagedResultDto<OrderedBookDto>> GetListAsync(GetOrderedBookListDto input)
        {
            var orders = await _orderedBookRepository.GetListAsync(
               input.SkipCount,
               input.MaxResultCount,
               input.Sorting
           );
            var users = await _userRepository.GetListAsync();
            var books = await _bookRepository.GetListAsync();

            var bookOrderDto = ObjectMapper.Map<List<OrderedBook>, List<OrderedBookDto>>(orders);
            bookOrderDto.ForEach((order) =>
            {
                order.ClientName = users.Find(user => user.Id == order.ClientId).UserName;
                order.BookName = books.Find(book => book.Id == order.BookId).Name;
            });

            var totalCount = await _orderedBookRepository.CountAsync();
            var admin = "admin";
            return _currentUser.Roles[0] == admin ? new PagedResultDto<OrderedBookDto>(totalCount, bookOrderDto) : null;
        }

        [Authorize(BookStorePermissions.OrderedBooks.ShowOrders)]
        public async Task<PagedResultDto<OrderedBookDto>> GetClientListAsync(GetOrderedBookListDto input)
        {
            var orders = await _orderedBookRepository.GetClientListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting
            );

            var user = await _userRepository.GetListAsync();
            var books = await _bookRepository.GetListAsync();

            var bookOrderDto = ObjectMapper.Map<List<OrderedBook>, List<OrderedBookDto>>(orders);

            bookOrderDto.ForEach((order) =>
            {
                order.ClientName = user.Find(user => user.Id == order.ClientId).UserName;
                order.BookName = books.Find(book => book.Id == order.BookId).Name;
            });


            var totalCount = orders.Count;

            return _currentUser.Roles[0] == "client" ? new PagedResultDto<OrderedBookDto>(totalCount, bookOrderDto) : null;
        }
    }
}


