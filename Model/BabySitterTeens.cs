namespace Model
{
    public class BabySitterTeens : User
    {
        private string mail;
        private int priceForAnHour;
        private string profilePicture;
        private int telephone;
        private string password;

        public string Mail { get => mail; set => mail = value; }
        public int PriceForAnHour { get => priceForAnHour; set => priceForAnHour = value; }
        public string ProfilePicture { get => profilePicture; set => profilePicture = value; }
        public int Telephone { get => telephone; set => telephone = value; }
        public string Password { get => password; set => password = value; }
        
    }
}
