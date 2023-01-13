using AutoMapper;
using FluentValidation;
using MovieAPI.Application.Cqrs.Queries.UserQueries;
using MovieAPI.Application.Dtos.UserDtos;
using MovieAPI.Application.Wrappers;
using MovieAPI.Domain.Entities;
using MovieAPI.Infrastructure.Data.Context;
using MovieAPI.Infrastructure.UnitOfWork;
using MediatR;
using System.Net;
using MovieAPI.Application.Cqrs.Queries.MovieQueries;
using MovieAPI.Application.Dtos.MovieDtos;
using MovieAPI.Application.Exceptions;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;

namespace MovieAPI.Application.Cqrs.QueryHandlers.MovieQueryHandlers;

public class GetMovieRecommendationByIdQueryHandler : IRequestHandler<GetMovieRecommendationByIdQuery, ApiResponse<MovieDto>>
{
    private readonly IUnitOfWork<AppDbContext> _unitOfWork;
    private readonly IMapper _mapper;

    public GetMovieRecommendationByIdQueryHandler(IUnitOfWork<AppDbContext> unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<MovieDto>> Handle(GetMovieRecommendationByIdQuery request, CancellationToken cancellationToken)
    {
        var existEntity = await _unitOfWork.GetRepository<Movie>().GetByIdAsync(request.Id);

        if (existEntity is null)
            throw new ValidationException("Movie is not found.");
        MailSender(existEntity, request.MailTo);
        return new ApiResponse<MovieDto>
        {
            Data = _mapper.Map<MovieDto>(existEntity),
            StatusCode = (int)HttpStatusCode.OK,
            IsSuccessful = true,
        };
    }
    private void MailSender(Movie movie,string mailTo)
    {
        var body = "<h1>" + movie.original_title + "<h1>";
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("elijah.quitzon5@ethereal.email"));
        email.To.Add(MailboxAddress.Parse(mailTo));
        email.Subject = "Film Önerilerimiz";
        email.Body = new TextPart(TextFormat.Html) { Text= body };
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
        smtp.Authenticate("elijah.quitzon5@ethereal.email", "kX6qhsnBgF1RWjzgQk");
        smtp.Send(email);
        smtp.Dispose();
       
    }
}