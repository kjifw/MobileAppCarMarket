namespace MobileCarMarket.Device
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Windows.Devices.Geolocation;

    public class Geolocation
    {
        public Geolocation()
        {

        }

        public async Task<bool> IsGeolocatorAllowed()
        {
            var geolocatorAccessStatus = await Geolocator.RequestAccessAsync().AsTask();

            if (geolocatorAccessStatus == GeolocationAccessStatus.Allowed)
            {
                return true;
            }

            return false;
        }

        public async Task<Coordinates> GetCoordinates()
        {
            var accessStatus = await Geolocator.RequestAccessAsync().AsTask(); ;

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:

                    var cancellationTokenSource = new CancellationTokenSource();
                    var token = cancellationTokenSource.Token;

                    var geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };
                    var pos = await geolocator.GetGeopositionAsync().AsTask(token);
                    
                    return new Coordinates()
                    {
                        Latitude = pos.Coordinate.Point.Position.Latitude,
                        Longitude = pos.Coordinate.Point.Position.Longitude
                    };

                case GeolocationAccessStatus.Denied:

                    throw new InvalidOperationException("Access denied to geolocator");

                case GeolocationAccessStatus.Unspecified:

                    throw new InvalidOperationException("Failed to capture location");
            }

            throw new InvalidOperationException();
        }
    }
}
