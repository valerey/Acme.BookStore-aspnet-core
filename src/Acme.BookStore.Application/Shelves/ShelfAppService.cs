using Acme.BookStore.Permissions;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Shelves
{
    public class ShelfAppService :
        CrudAppService<
            Shelf, //The Book entity
            ShelfDto, //Used to show shelves
            Guid, //Primary key of the shelf entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateShelfDto>, //Used to create/update a shelf
        IShelfAppService //implement the IShelfAppService
    {
        public ShelfAppService(IRepository<Shelf, Guid> repository)
           : base(repository)
        {
            GetPolicyName = BookStorePermissions.Shelves.Default;
            GetListPolicyName = BookStorePermissions.Shelves.Default;
            CreatePolicyName = BookStorePermissions.Shelves.Create;
            UpdatePolicyName = BookStorePermissions.Shelves.Edit;
            DeletePolicyName = BookStorePermissions.Shelves.Delete;
        }
    }
}
