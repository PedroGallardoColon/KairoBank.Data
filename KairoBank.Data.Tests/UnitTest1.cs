namespace KairoBank.Data.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using var db = new KaironBankDBContext("Data Source=(local)\\sqlexpress;Initial Catalog=KaironBankDB;Integrated Security=True");
            db.Users.Add(new User
            {
                Balance = 10,
                Name = "The User Name",
                Offers = new Offer[] { new Offer
                                 {
                                     SpecialityCode ="DEV",
                                     From=new DateTime(2022,1,1),
                                     To =new DateTime(2022,12,31)
                                 },
                                 new Offer{
                                    SpecialityCode="DOG",
                                    From=new DateTime(2022,4,1),
                                    To=new DateTime(2022,5,1)
                                    }
                }
            }
                 );
            db.SaveChanges();
        }
    }
}