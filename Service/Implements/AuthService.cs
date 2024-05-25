using AutoMapper;
using myProject._mail_config;
using myProject._mail_config.Interface;
using myProject._mail_config.Template;
using myProject.Authorization.Interfaces;
using myProject.Config;
using myProject.Context;
using myProject.Dtos.Auth;
using myProject.Entities;
using myProject.Service.Interfaces;
using myProject.Utils;
using myProject.Utils.Enums;

namespace myProject.Service.Implements;

public class AuthService : IAuthService
{
    private SQLServerDBContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;
    private IEmailSender _emailSender;

    public AuthService(
        SQLServerDBContext context,
        IJwtUtils jwtUtils,
        IMapper mapper,
        IEmailSender emailSender)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
        _emailSender = emailSender;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.User.SingleOrDefault(x => x.username == model.username);

        // // validate
        // if (user == null || !BCrypt.Net.BCrypt.Verify(model.password, user.password))
        //     throw new AppException(Constants.account_email_password_incorrect);

        // if (user.isVerify == false)
        //     throw new AppException(Constants.account_not_verified);

        // if (user.status == Enums.UserStatus.INACTIVE)
        //     throw new AppException(Constants.account_not_active);

        // if (user.status == Enums.UserStatus.BLOCKED)
        //     throw new AppException(Constants.account_blocked);

        // if (user.status == Enums.UserStatus.BANNED)
        //     throw new AppException(Constants.account_banned);

        // if (user.status == Enums.UserStatus.DELETED)
        //     throw new AppException(Constants.account_deleted);

        // authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.token = _jwtUtils.GenerateToken(user);
        return response;
    }

    public void Register(RegisterRequest model)
    {
        // validate
        if (_context.User.Any(x => x.username == model.username))
            throw new AppException("Username '" + model.username + "' is already taken");

        if (_context.User.Any(x => x.email == model.email))
            throw new AppException("Email '" + model.email + "' is already taken");

        if (model.username == null || model.password == null)
            throw new AppException(Constants.account_email_password_required);

        if (model.email == null)
            throw new AppException(Constants.account_email_required);

        if (model.password.Length < 6)
            throw new AppException(Constants.account_password_invalid);

        if (model.password != model.confirmPassword)
            throw new AppException(Constants.account_password_incorrect);

        // map model to new user object
        var user = _mapper.Map<User>(model);
        user.role = Enums.Role.USER;

        // hash password
        user.password = BCrypt.Net.BCrypt.HashPassword(model.password);
        user.status = Enums.UserStatus.INACTIVE;
        // generate verify code
        ProjectUtils projectUtils = new ProjectUtils();
        var code = projectUtils.generateCode();
        user.verifyCode = code;
        // send code to email
        var content = RegisterMail.body;
        content = content.Replace("my_email_replace", model.email);
        content = content.Replace("my_code_replace", code);
        var message = new Message(new string[] { model.email }, Constants.EMAIL_VERIFY, content);
        _emailSender.SendEmail(message);
        // save user
        _context.User.Add(user);
        _context.SaveChanges();
    }

    public void VerifyUser(RegisterRequest model)
    {
        var user = _context.User.SingleOrDefault(x => x.email == model.email);

        if (user == null)
        {
            throw new AppException(Constants.account_not_found);
        }

        if (model.code == null)
        {
            throw new AppException(Constants.account_verify_empty);
        }

        if (user.verifyCode != model.code)
        {
            throw new AppException(Constants.account_verifycode_incorrect);
        }

        // active account
        user.verifyCode = "";
        user.isVerify = true;
        user.status = Enums.UserStatus.ACTIVE;
        user.UpdatedAt = DateTimeOffset.Now.AddHours(7);
        _context.User.Update(user);
        _context.SaveChanges();
    }

    private void ActiveUser(string email)
    {
        var user = _context.User.SingleOrDefault(x => x.email == email);
        if (user != null)
        {
            user.verifyCode = "";
            user.isVerify = true;
            user.status = Enums.UserStatus.ACTIVE;
            user.UpdatedAt = DateTimeOffset.Now.AddHours(7);
            _context.User.Update(user);
        }
    }

    public void ForgotPassword(RegisterRequest model)
    {
        var user = _context.User.SingleOrDefault(x => x.email == model.email);

        if (model.email == null)
        {
            throw new AppException(Constants.account_email_required);
        }

        if (user == null)
        {
            throw new AppException(Constants.account_not_found);
        }

        if (user.isVerify == false)
        {
            throw new AppException(Constants.account_not_verified);
        }

        if (user.status == Enums.UserStatus.INACTIVE)
        {
            throw new AppException(Constants.account_not_active);
        }

        if (user.status == Enums.UserStatus.BLOCKED)
        {
            throw new AppException(Constants.account_blocked);
        }

        if (user.status == Enums.UserStatus.BANNED)
        {
            throw new AppException(Constants.account_banned);
        }

        if (user.status == Enums.UserStatus.DELETED)
        {
            throw new AppException(Constants.account_deleted);
        }

        // generate verify code
        ProjectUtils projectUtils = new ProjectUtils();
        var code = projectUtils.generateCode();
        user.verifyCode = code;
        // save user
        _context.User.Update(user);
        // send code to email
        var content = ForgotPasswordMail.body;
        content = content.Replace("my_email_replace", model.email);
        content = content.Replace("my_code_replace", code);
        var message = new Message(new string[] { model.email }, Constants.EMAIL_FORGOT, content);
        _emailSender.SendEmail(message);
        // save credential
        _context.SaveChanges();
    }

    public void VerifyChangePassForgot(RegisterRequest model)
    {
        var user = _context.User.SingleOrDefault(x => x.email == model.email);

        if (user == null)
        {
            throw new AppException(Constants.account_not_found);
        }

        if (model.code == null)
        {
            throw new AppException(Constants.account_verify_empty);
        }

        if (user.verifyCode != model.code)
        {
            throw new AppException(Constants.account_verifycode_incorrect);
        }

        if (model.password != model.confirmPassword)
        {
            throw new AppException(Constants.account_password_incorrect);
        }

        ChangePass(model.email, model.password);
    }


    private void ChangePass(string email, string password)
    {
        var user = _context.User.SingleOrDefault(x => x.email == email);
        user.verifyCode = "";
        user.isVerify = true;
        // hash password if it was entered
        if (!string.IsNullOrEmpty(password))
        {
            user.password = BCrypt.Net.BCrypt.HashPassword(password);
        }

        user.UpdatedAt = DateTimeOffset.Now.AddHours(7);
        _context.User.Update(user);
    }
}