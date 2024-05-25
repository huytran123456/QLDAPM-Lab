using AutoMapper;
using myProject.Dtos.Auth;
using myProject.Dtos.Books;
using myProject.Dtos.Borrow;
using myProject.Dtos.User;
using myProject.Entities;

namespace myProject.Config;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // User -> AuthenticateResponse
        CreateMap<User, AuthenticateResponse>();

        // User -> UserResponse
        CreateMap<User, UserResponse>();

        // RegisterRequest -> User
        CreateMap<RegisterRequest, User>();

        // CreateRequest -> User
        CreateMap<CreateRequest, User>();

        // UpdateRequest -> User
        CreateMap<UpdateRequest, User>();

        //Books
        // Books -> BookResponse
        CreateMap<Books, BookResponse>();
        // CreateBookRequest -> Books
        CreateMap<CreateBookRequest, Books>();
        // UpdateBookRequest -> Books
        CreateMap<UpdateBookRequest, Books>();
        
        //Borrow
        // Borrow -> BorrowResponse
        CreateMap<Borrow, BookResponse>();
        // CreateBorrow -> Borrow
        CreateMap<CreateBorrow, Borrow>();
        // UpdateBorrow -> Borrow
        CreateMap<UpdateBorrow, Borrow>();
    }
}