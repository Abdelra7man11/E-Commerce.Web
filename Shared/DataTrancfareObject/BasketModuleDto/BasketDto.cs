using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTrancfareObject.BasketModuleDto
{
    public class BasketDto
    {
        public string Id { get; set; } // Guid  Created From FrontEnd
        public ICollection<BasketItemDto> Items { get; set; } = [];
    }
}
