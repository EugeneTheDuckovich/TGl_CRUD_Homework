namespace CRUD_src.Data;

public class MusicalInstrument
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Productor { get; set; }
    public string Model { get; set; }
    public string Material { get; set; }

    public MusicalInstrument() { }

    public MusicalInstrument(int id, string type, string productor, string model, string material)
    {
        Id = id;
        Type = type;
        Productor = productor;
        Model = model;
        Material = material;
    }
}
