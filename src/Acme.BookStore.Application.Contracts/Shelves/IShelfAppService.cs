using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Shelves
{
    public interface IShelfAppService :
        ICrudAppService< //Defines CRUD methods
            ShelfDto, //Used to show shelves
            Guid, //Primary key of the shelf entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateShelfDto> //Used to create/update a shelves
    {
    }
}
