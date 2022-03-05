namespace Helperland_Clone.Services
{
    public interface IUserService
    {
        string GetUserId();
        string GetUserName();
        string GetUserTypeId();
        bool IsAuthenticated();
    }
}