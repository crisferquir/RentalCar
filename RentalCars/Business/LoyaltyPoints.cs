using RentalCars.Models;

namespace RentalCars.Business
{
    public class LoyaltyPoints
    {
        private const int PREMIUM_POINTS = 5;
        private const int SUV_POINTS = 3;
        private const int SMALL_POINTS = 1;

        public static int CalculatePoints(string carType)
        {
            int points = 0;

            switch (carType)
            {
                case "Premium":
                    points = PREMIUM_POINTS;
                    break;
                case "SUV":
                    points = SUV_POINTS;
                    break;
                case "Small":
                    points = SMALL_POINTS;
                    break;
                default:
                    break;
            }

            return points;
        }
    }

}
