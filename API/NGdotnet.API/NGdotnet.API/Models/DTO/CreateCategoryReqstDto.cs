using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace NGdotnet.API.Models.DTO
{
    public class CreateCategoryReqstDto
    {
        public string Name { get; set; }

        public string UrlHandle { get; set; }
    }
}

