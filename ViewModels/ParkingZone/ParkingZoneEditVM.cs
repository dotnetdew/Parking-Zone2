namespace Parking_Zone.ViewModels.ParkingZone
{
    public class ParkingZoneEditVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public static Models.ParkingZone MapTo(ParkingZoneEditVM vm, Guid id)
        {
            return new Models.ParkingZone
            {
                Id = id,
                Name = vm.Name,
                Address = vm.Address,
                Description = vm.Description,
            };
        }
    }
}
