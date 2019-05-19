using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Entities;
using BLL.BusinessModels;

namespace Util
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<UserDTO, ApplicationUser>().ReverseMap();
            //CreateMap<BookDTO, Book>().ReverseMap();
            CreateMap<TagDTO, Tag>().ReverseMap();
            CreateMap<MarkDTO, Mark>().ReverseMap();
            CreateMap<BookDTO, Book>();
            CreateMap<Book, BookDTO>().ForMember("Mark", opt =>
                opt.MapFrom( (m) =>  m.Marks.Count == 0 ? 0 : MarkCalculation.CalculateMark(m)))
                .ForMember("UserName", opt => opt.MapFrom(b => b.ApplicationUser.UserName));

        }
    }
}
