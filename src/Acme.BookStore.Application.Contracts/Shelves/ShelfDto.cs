﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Shelves
{
    public class ShelfDto : AuditedEntityDto<Guid>
    {       
        public string Name { get; set; }
    }
}
