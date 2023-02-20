namespace Ob_opg._1
{
    public class Car
    {

        // Property uden constraints

        public int Id { get; set; }


        // Properties med constraints

        public string Model { get; set; }

        public double Price { get; set; }

        public string Licenseplate { get; set; }


       /*
        *  To string metode
        */
        
        public override string ToString()
        {
            return Id + " " + Model + " " + Price + " " + Licenseplate;
        }



        // Tjekker for constraints


        public void ValidateModel()
        {
            if (Model == null)
                throw new ArgumentNullException("model is null");
            if (Model.Length < 4)
                throw new ArgumentException("model must be at least 4 characters: " + Model);
        }

        public void ValidatePrice()
        {
            if (Price > 0)
                throw new ArgumentOutOfRangeException("price must be above 0 " + Price);
        }

        public void ValidateLicensePlate()
        {
           if (Licenseplate == null)
                throw new ArgumentNullException("Licenseplate is null");
            if (Licenseplate.Length <= 2 || Licenseplate.Length > 7)
                throw new ArgumentException("If length is less or equal to 2 or more than 7");
        }

        public void Validate()
        {
            ValidateModel();
            ValidatePrice();
            ValidateLicensePlate();
        }




















    }
}