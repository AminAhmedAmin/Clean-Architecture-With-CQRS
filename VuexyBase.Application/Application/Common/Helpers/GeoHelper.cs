using VuexyBase.Domain.Enums.Geo;

namespace VuexyBase.Application.Common.Helpers
{
    public static class GeoHelper
    {
        public static double GetDistance(double sLat, double sLng, double eLat, double eLng, DistanceUnit unit = DistanceUnit.Kilometers)
        {
            try
            {
                // Convert degrees to radians
                sLat = DegreesToRadians(sLat);
                sLng = DegreesToRadians(sLng);
                eLat = DegreesToRadians(eLat);
                eLng = DegreesToRadians(eLng);

                // Haversine formula
                double dLat = eLat - sLat;
                double dLng = eLng - sLng;

                double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                           Math.Cos(sLat) * Math.Cos(eLat) *
                           Math.Sin(dLng / 2) * Math.Sin(dLng / 2);

                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                // Radius of Earth in kilometers
                double radius = 6371;

                // Distance in kilometers
                double distanceInKm = radius * c;

                // Convert the distance based on the selected unit
                switch (unit)
                {
                    case DistanceUnit.Kilometers:
                        return Math.Round(distanceInKm, 1, MidpointRounding.ToEven);
                    case DistanceUnit.Meters:
                        return Math.Round(distanceInKm * 1000, 1, MidpointRounding.ToEven);  // Convert km to meters
                    case DistanceUnit.Miles:
                        return Math.Round(distanceInKm * 0.621371, 1, MidpointRounding.ToEven);  // Convert km to miles
                    default:
                        throw new ArgumentOutOfRangeException(nameof(unit), "Invalid distance unit.");
                }
            }
            catch (Exception)
            {
                return 0.0;
            }
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }
    }
}
