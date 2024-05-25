using AutoMapper;
using myProject.Config;
using myProject.Context;
using myProject.Dtos.User;
using myProject.Entities;
using myProject.Service.Interfaces;
using myProject.Utils;
using myProject.Utils.Enums;

namespace myProject.Service.Implements;

public class UserService : IUserService
{
    private SQLServerDBContext _context;
    private readonly IMapper _mapper;

    public UserService(
        SQLServerDBContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.User.Where(v => v.status != Enums.UserStatus.DELETED).ToList();
    }

    public IEnumerable<User> GetAllByStatus(Enums.UserStatus status)
    {
        status = Enums.UserStatus.ACTIVE;
        return _context.User.Where(v => v.status == status).ToList();
    }

    public User GetById(int id)
    {
        return getUser(id);
    }

    public User GetByIdAndStatus(int id)
    {
        return getUserByIdAndStatus(id);
    }

    public void ChangPass(int id, ChangePasswordRequest model)
    {
        var user = getUser(id);

        if (model.password.Length < 6 || model.oldPassword.Length < 6)
            throw new AppException("Password invalid!");

        if (model.password != model.confirmPassword)
            throw new AppException("Password or Password Confirm incorrect!");


        if (!BCrypt.Net.BCrypt.Verify(model.oldPassword, user.password))
            throw new AppException("Old password is incorrect!");

        // hash password if it was entered
        if (!string.IsNullOrEmpty(model.password))
            user.password = BCrypt.Net.BCrypt.HashPassword(model.password);

        user.UpdatedAt = DateTimeOffset.Now.AddHours(7);
        user.UpdatedBy = id;

        // copy model to user and save
        _context.User.Update(user);
        _context.SaveChanges();
    }

    public void UpdateInfo(int id, UpdateRequest model)
    {
        var user = getUser(id);

        if (user.username != model.username)
        {
            if (_context.User.Any(x => x.username == model.username))
                throw new AppException("User with the username '" + model.username + "' already exists");
        }

        if (user.email != model.email)
        {
            if (_context.User.Any(x => x.email == model.email))
                throw new AppException("User with the email '" + model.email + "' already exists");
        }

        user.UpdatedAt = DateTimeOffset.Now.AddHours(7);
        user.UpdatedBy = id;
        // copy model to user and save
        user.username = model.username;
        user.email = model.email;
        user.phoneNumber = model.phoneNumber;
        user.birthday = model.birthday;
        user.gender = model.gender;
        user.firstName = model.firstName;
        user.lastName = model.lastName;
        user.address = model.address;
        _context.User.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = getUser(id);
        user.status = Enums.UserStatus.DELETED;
        user.DeletedAt = DateTimeOffset.Now.AddHours(7);
        _context.User.Update(user);
        _context.SaveChanges();
    }

    public void Create(CreateRequest model)
    {
        // validate
        if (_context.User.Any(x => x.username == model.username))
            throw new AppException("User with the username '" + model.username + "' already exists");

        if (model.username == null || model.password == null)
            throw new AppException("Username or Password invalid!");

        if (model.password.Length < 6)
            throw new AppException("Password invalid!");

        if (model.password != model.confirmPassword)
            throw new AppException("Password or Password Confirm incorrect!");

        // map model to new user object
        var user = _mapper.Map<User>(model);

        // hash password
        user.password = BCrypt.Net.BCrypt.HashPassword(model.password);

        user.CreatedAt = DateTimeOffset.Now.AddHours(7);
        // save user
        _context.User.Add(user);
        _context.SaveChanges();
    }

    private User getUser(int id)
    {
        var user = _context.User.Find(id);
        if (user == null || user.status == Enums.UserStatus.DELETED)
            throw new KeyNotFoundException("User not found");
        return user;
    }

    private User getUserByIdAndStatus(int id)
    {
        var user = _context.User.Find(id);
        if (user == null || user.status != Enums.UserStatus.ACTIVE)
            throw new KeyNotFoundException("User not found");
        return user;
    }
}