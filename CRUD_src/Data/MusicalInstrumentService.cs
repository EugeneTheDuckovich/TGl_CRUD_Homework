using Bogus;

namespace CRUD_src.Data;

public class MusicalInstrumentService
{
    private static string[] TypeDictionary = { "Guitar", "Piano", "Cello" };
    private static string[] ProductorDictionary = { "YAMAHA", "Behringer", "Fender" };
    private static string[] MaterialDictionary = { "Spruce", "Birch", "beech" };
    public List<MusicalInstrument> Instruments { get; private set; }

    public MusicalInstrumentService()
    {
        var instrumentFaker = new Faker<MusicalInstrument>()
            .RuleFor(instrument => instrument.Id, faker => faker.IndexFaker)
            .RuleFor(instrument => instrument.Type, faker => TypeDictionary[Random.Shared.Next(TypeDictionary.Length)])
            .RuleFor(instrument => instrument.Model, faker => (faker.Random.Int(1, 10) * 100).ToString())
            .RuleFor(instrument => instrument.Productor, faker => ProductorDictionary[Random.Shared.Next(ProductorDictionary.Length)])
            .RuleFor(instrument => instrument.Material, faker => MaterialDictionary[Random.Shared.Next(MaterialDictionary.Length)]);

        Instruments = instrumentFaker.Generate(26);
        Instruments.Remove(Instruments.First());
    }

    public List<MusicalInstrument> GetAll()
    {
        return Instruments.OrderBy(instrument => instrument.Id).ToList();
    }

    public MusicalInstrument GetInstrument(int id)
    {
        return Instruments.First(instrument => instrument.Id == id);
    }

    public void UpdateInstrument(MusicalInstrument instrument)
    {
        Instruments.Remove(Instruments.First(i => i.Id == instrument.Id));
        Instruments.Add(instrument);
    }

    public void AddInstrument(MusicalInstrument instrument)
    {
        Instruments.Add(instrument);
    }

    public void DeleteInstrument(int id)
    {
        Instruments.Remove(Instruments.First(instrument => instrument.Id == id));
    }
}