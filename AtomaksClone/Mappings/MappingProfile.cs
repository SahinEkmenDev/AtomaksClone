using AutoMapper;
using AtomaksClone.Models;
using AtomaksClone.DTOs;
using AtomaksClone.DTOs.AtomaksClone.DTOs;

namespace AtomaksClone.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product mappings
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            // Question mappings
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Question, CreateQuestionDto>().ReverseMap();
            CreateMap<Question, UpdateQuestionDto>().ReverseMap();

            // Answer mappings
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<Answer, CreateAnswerDto>().ReverseMap();
            CreateMap<Answer, UpdateAnswerDto>().ReverseMap();

            // AnswerImpact mappings
            CreateMap<AnswerImpact, AnswerImpactDto>().ReverseMap();
            CreateMap<AnswerImpact, CreateAnswerImpactDto>().ReverseMap();
            CreateMap<AnswerImpact, UpdateAnswerImpactDto>().ReverseMap();

            // Quiz Product recommendation
            CreateMap<Product, ProductRecommendationDto>();
        }
    }
}
