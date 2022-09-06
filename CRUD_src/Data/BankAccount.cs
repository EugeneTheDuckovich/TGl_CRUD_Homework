namespace CRUD_src.Data
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int Balance { get; set; }
        public int Userid { get; set; }
        public User Owner { get; set; }
    }
}
