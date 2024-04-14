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
                avatar = "https://img.myloview.com/stickers/default-avatar-profile-icon-vector-social-media-user-photo-700-205577532.jpg",
                role = Enums.Role.ADMIN, username = "admin", email = "admin@gmail.com",
                firstName = "supper", lastName = "admin", isVerify = true,
                phoneNumber = "0989889889", address = "Ha Noi",
                birthday = "10-02-2003", gender = "Male", status = Enums.UserStatus.ACTIVE,
                password = BCrypt.Net.BCrypt.HashPassword("123456")
            },
            new User()
            {
                id = 2, 
                avatar = "https://img.myloview.com/stickers/default-avatar-profile-icon-vector-social-media-user-photo-700-205577532.jpg",
                role = Enums.Role.USER, username = "user", email = "user@gmail.com",
                firstName = "User", lastName = "New", isVerify = true,
                phoneNumber = "0968886868", address = "Ha Noi",
                birthday = "01-01-2003", gender = "Male", status = Enums.UserStatus.ACTIVE,
                password = BCrypt.Net.BCrypt.HashPassword("123456")

            }
        );
        modelBuilder.Entity<Categories>().HasData(
            new Categories()
            {
                id = 1, category = "Truyện tranh", status = Enums.CategoryStatus.ACTIVE
            },
            new Categories()
            {
                id = 2, category = "Tiểu thuyết", status = Enums.CategoryStatus.ACTIVE
            },
            new Categories()
            {
                id = 3, category = "Khoa học viễn tưởng", status = Enums.CategoryStatus.ACTIVE
            },
            new Categories()
            {
                id = 4, category = "Tri thức", status = Enums.CategoryStatus.ACTIVE
            }
        );
        /*modelBuilder.Entity<Books>().HasData(
            new Books()
            {
                id = 1, category_id = 1, description = "Books",
                thumbnail = "https://insurshtml.websitelayout.net/img/service/service-details9.jpg?fbclid=IwAR0TDjs4fMdeSZnUjKu4emaQpgKbbOBzvHxf91clFsb8kWnX2os_zTv7XLc", 
                name = "Home Insurance",
                status = Enums.BookStatus.ACTIVE, price = "999.99"
            },
            new Books()
            {
                id = 2, category_id = 2, description = "Books",
                thumbnail = "https://insurshtml.websitelayout.net/img/service/service-details.jpg?fbclid=IwAR2Vgtt-qe_wWKrac9bIeuZTGDzwJ-ZAO6MbZegkWjKOabVghZWSbg0nb-s",
                name = "Life Insurance",
                status = Enums.BookStatus.ACTIVE, price = "599.99"
            },
            new Books()
            {
                id = 3, category_id = 3, description = "Books",
                thumbnail = "https://insurshtml.websitelayout.net/img/service/service-details7.jpg?fbclid=IwAR2Vgtt-qe_wWKrac9bIeuZTGDzwJ-ZAO6MbZegkWjKOabVghZWSbg0nb-s",
                name = "Motor Insurance",
                status = Enums.BookStatus.ACTIVE, price = "399.99"
            },
            new Books()
            {
                id = 4, category_id = 4, description = "Books",
                thumbnail = "https://insurshtml.websitelayout.net/img/service/service-details8.jpg?fbclid=IwAR1IgI4eoC6bLiIbvgsfE0TvAEAe-NBdKWAVwpIgdqD-DkC4eO6sAOVetJ4",
                name = "Medical Insurance",
                status = Enums.BookStatus.ACTIVE, price = "399.99"
            }
        );*/
    }
}