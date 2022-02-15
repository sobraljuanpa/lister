using DataAccess.Repositories;
using Domain;
using Domain.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services;
public class UserService : IUserService
{
    private readonly UserRepository _repository;

    public UserService(UserRepository repository)
    {
        _repository = repository;
    }

    private User Map(UserDTO userDTO)
    {
        return new User 
        { 
            Email = userDTO.Email,
            Name = userDTO.Name,
            Password = userDTO.Password,
            IsEnabled = userDTO.IsEnabled
        };
    }

    public string Authenticate(CredentialsDTO credentials)
    {
        string token = string.Empty;
        var users = _repository.GetAll();
        User? loggedUser = null;
        
        foreach (var user in users)
        {
            if(user.Email.Equals(credentials.Email) && user.Password.Equals(credentials.Password)) loggedUser = user;
        }

        if (loggedUser != null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Nacional el primero y el mas grande");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, loggedUser.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var auxToken = tokenHandler.CreateToken(tokenDescriptor);
            token = tokenHandler.WriteToken(auxToken);
        }

        return token;
    }

    public User GetUser(int id)
    {
        return _repository.Get(id);
    }

    public IQueryable<User> GetAllUsers()
    {
        return _repository.GetAll();
    }

    public void AddUser(UserDTO user)
    {
        _repository.Add(Map(user));
    }

    public void DeleteUser(int id)
    {
        _repository.Delete(id);
    }

    public void UpdateUser(int id, UserDTO user)
    {
        _repository.Update(id, Map(user));
    }

}
