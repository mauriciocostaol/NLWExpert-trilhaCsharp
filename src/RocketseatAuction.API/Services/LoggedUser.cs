﻿using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Services;

public class LoggedUser
{
    private readonly IHttpContextAccessor _httpContextAcessor;
    private readonly IUsersRepository _repository;
    public LoggedUser(IHttpContextAccessor httpContext,IUsersRepository repository)
    {
        _httpContextAcessor = httpContext;
        _repository = repository;
    }
    public User User()
    {
       

        var token = TokenOnRequest();
        var email = FromBase64String(token);

        return _repository.GetUserByEmail(email);
    }
    private string TokenOnRequest()
    {
        var authentication = _httpContextAcessor.HttpContext!.Request.Headers.Authorization.ToString();

        
        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);

        return System.Text.Encoding.UTF8.GetString(data);
    }
}
