namespace CRUD_src.Data;

public class Guitar
{
    public int Id { get; set; }
    public string Productor { get; set; }
    public string Model { get; set; }
    public string Material { get; set; }
    public StringsKit StringsKit { get; set; }
    public List<User> Buyers { get; set; }
}
