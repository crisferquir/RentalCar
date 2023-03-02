using RentalCars.Models;
namespace RentalCars.Business
{
    public class RentalService
    {
        private const double PremiumPrice = 300;
        private const double SuvPrice = 150;
        private const double SmallPrice = 50;

        public static double CalculatePrice(string carType, int rentalDays, int extraDays )
        {
            switch (carType)
            {
                case "Premium":
                    double premiumPrice = PremiumPrice * rentalDays;
                    if (extraDays > 0)
                    {
                        premiumPrice += PremiumPrice * 0.2 * extraDays;
                    }
                    return premiumPrice;

                case "SUV":
                    double suvPrice;
                    if (rentalDays < 7)
                    {
                        suvPrice = SuvPrice * rentalDays;
                    }
                    else if (rentalDays <= 30)
                    {
                        suvPrice = SuvPrice * 7 + 0.8 * SuvPrice * (rentalDays - 7);
                    }
                    else
                    {
                        suvPrice = SuvPrice * 7 + 0.8 * SuvPrice * 23 + 0.5 * SuvPrice * (rentalDays - 30);
                    }
                    if (extraDays > 0)
                    {
                        suvPrice += SmallPrice * 0.6 * extraDays;
                    }
                    return suvPrice;

                case "Small":
                    double smallPrice;
                    if (rentalDays <= 7)
                    {
                        smallPrice = SmallPrice * rentalDays;
                    }
                    else
                    {
                        smallPrice = SmallPrice * 7 + 0.6 * SmallPrice * (rentalDays - 7);
                    }
                    if (extraDays > 0)
                    {
                        smallPrice += SmallPrice * 0.3 * extraDays;
                    }
                    return smallPrice;

                default:
                    throw new ArgumentException("Invalid car type.");
            }
        }
    }



}
