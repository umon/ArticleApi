using ArticleApi.Dtos;
using ArticleApi.Models;
using AutoMapper;

namespace ArticleApi.Helpers
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ArticleCreateDto, Article>();
            CreateMap<ArticleUpdateDto, Article>()
                .ForAllMembers(options =>
                    options.Condition((source, destanation, sourceMember) => sourceMember != null));
        }
    }
}