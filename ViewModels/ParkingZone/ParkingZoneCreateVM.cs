using Parking_Zone.Models;
namespace Parking_Zone.ViewModels.ParkingZone
{
    public class ParkingZoneCreateVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public static Parking_Zone.Models.ParkingZone MapToModel(ParkingZoneCreateVM vm)
        {
            return new Models.ParkingZone
            {
                Id = Guid.NewGuid(),
                Name = vm.Name,
                Address = vm.Address,
                DateOfEstablishment = DateTime.UtcNow,
                Description = vm.Description,
            };
        }
    }
}
