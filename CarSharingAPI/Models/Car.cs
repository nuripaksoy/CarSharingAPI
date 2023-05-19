using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace CarSharingAPI.Models
{
    [PrimaryKey(nameof(Plate))]
    public class Car
    {
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public User Owner { get; set; }
        public int UserId { get; set; }
    }
}
