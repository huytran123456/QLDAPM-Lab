using Microsoft.EntityFrameworkCore;
using myProject.Entities;
using myProject.Utils;
using myProject.Utils.Enums;

namespace myProject.Context;

public class DbInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        modelBuilder.Entity<User>().HasData(
            new User()
            {
                id = 1,
                avatar =
                    "https://img.myloview.com/stickers/default-avatar-profile-icon-vector-social-media-user-photo-700-205577532.jpg",
                role = Enums.Role.ADMIN, username = "admin", email = "admin@gmail.com",
                firstName = "supper", lastName = "admin", isVerify = true,
                phoneNumber = "0989889889", address = "Ha Noi",
                birthday = "10-02-2003", gender = "Male", status = Enums.UserStatus.ACTIVE,
                password = BCrypt.Net.BCrypt.HashPassword("123456")
            },
            new User()
            {
                id = 2,
                avatar =
                    "https://img.myloview.com/stickers/default-avatar-profile-icon-vector-social-media-user-photo-700-205577532.jpg",
                role = Enums.Role.USER, username = "user", email = "user@gmail.com",
                firstName = "User", lastName = "New", isVerify = true,
                phoneNumber = "0968886868", address = "Ha Noi",
                birthday = "01-01-2003", gender = "Male", status = Enums.UserStatus.ACTIVE,
                password = BCrypt.Net.BCrypt.HashPassword("123456")
            }
        );
        modelBuilder.Entity<Books>().HasData(
            new Books()
            {
                id = 1, title = "Mắt biếc",
                thumbnail = "/images/mat_biec.jpeg",
                author = "Nguyễn Nhật Ánh",
                publisher = "Nhà xuất bản Trẻ",
                publish_date = DateTimeOffset.Now,
                genre = "Tiểu thuyết",
                quantity = 100,
                description = "",
                status = Enums.BookStatus.ACTIVE
            },
            new Books()
            {
                id = 2, title = "Doraemon",
                thumbnail = "/images/doraemon.jpeg",
                author = "Fujiko F. Fujio",
                publisher = "Nhà xuất bản Kim Đồng",
                publish_date = DateTimeOffset.Now,
                genre = "Truyện tranh",
                quantity = 300,
                description = "",
                status = Enums.BookStatus.ACTIVE
            },
            new Books()
            {
                id = 3, title = "Thư Viện Tri Thức Dành Cho Học Sinh - Những Câu Chuyện Thiên Văn Thú Vị (Tái bản )",
                thumbnail = "/images/nhung-cau-chuyen-thien-van-thu-vi-267269.jpeg",
                author = "Lâm Lâm",
                publisher = "Nhà xuất bản Mỹ Thuật",
                publish_date = DateTimeOffset.Now,
                genre = "Sách",
                quantity = 10,
                description = "",
                status = Enums.BookStatus.ACTIVE
            },
            new Books()
            {
                id = 4, title = "Chiến tranh và hòa bình",
                thumbnail = "/images/Tieu_thuyet_hay_Chien_tranh_va_hoa_binh_bd67032825.jpg",
                author = "Lev Tolstoy",
                publisher = "Nhà xuất bản Thành phố",
                publish_date = DateTimeOffset.Now,
                genre = "Tiểu thuyết",
                quantity = 50,
                description = "",
                status = Enums.BookStatus.ACTIVE
            }
        );
    }
}