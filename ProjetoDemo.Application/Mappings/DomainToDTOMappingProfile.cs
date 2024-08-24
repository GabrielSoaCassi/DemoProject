using AutoMapper;
using ProjetoDemo.Application.DTOs;
using ProjetoDemo.Application.Products.Commands;
using ProjetoDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Application.Mappings
{
    public class DomainToDTOMappingProfile:Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
        }
    }
}
