namespace myProject.Utils.Enums;

public class Enums
{
    public enum Role
    {
        ADMIN,
        USER
    }
    
    public enum UserStatus
    {
        ACTIVE,
        INACTIVE,
        BLOCKED,
        BANNED,
        DELETED
    }
    
    public enum BookStatus
    {
        ACTIVE,
        INACTIVE,
        DELETED
    }
    
    public enum BorrowStatus
    {
        PENDING,
        RETURN,
        RENT,
        DELETED
    }
}