namespace CRUD_src.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BankAccount BankAccount { get; set; }
        public List<Guitar> Guitars { get; set; }
    }
}
