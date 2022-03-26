using Helperland_Clone.Models;
using System.Text.Json.Serialization;

namespace Helperland_Clone.ViewModels
{
    public class FavoriteAndBlockedViewModel
    {
        public int Id { get; set; }
        public string Req { get; set; }

        public User user { get; set; }

        public FavoriteAndBlocked favoriteAndBlocked { get; set; }
    }
}
