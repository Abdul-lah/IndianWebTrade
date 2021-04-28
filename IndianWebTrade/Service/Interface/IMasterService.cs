using INFASTRUCTURE.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
  public  interface IMasterService
    {
        List<CategoryDto> GetCategories();
    }
}
