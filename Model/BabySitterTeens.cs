namespace Model
{
    public class BabySitterTeens : User
    {
        private string mailOfRecommender;
        private int priceForAnHour;
        private string profilePicture;
        private int telephone;


        public string MailOfRecommender { get => mailOfRecommender; set => mailOfRecommender = value; }
        public int PriceForAnHour { get => priceForAnHour; set => priceForAnHour = value; }
        public string ProfilePicture { get => profilePicture; set => profilePicture = value; }
        public int Telephone { get => telephone; set => telephone = value; }
    }
}
