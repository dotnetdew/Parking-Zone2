namespace Parking_Zone.ViewModels.ParkingZone
{
    public class ParkingZoneDetailsVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfEstablishment { get; set; }

        public static IEnumerable<ParkingZoneDetailsVM> MapTo(IEnumerable<Models.ParkingZone> zones)
        {
            var VMs = zones.Select(x => new ParkingZoneDetailsVM
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                DateOfEstablishment = x.DateOfEstablishment,
            });
            return VMs;
        }
    }
}
