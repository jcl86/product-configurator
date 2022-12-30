using Bogus;

namespace ProductConfigurator.FunctionalTests.Scenarios;

public class ImageMother
{
    private static readonly string[] images = new string[]
    {
        "pic001.jpg",
        "pic002.jpg",
        "pic003.jpg",
        "pic004.jpg",
        "pic005.jpg"
    };

    public static byte[] Create(Faker faker)
    {
        string image = faker.PickRandom(images);
        byte[] file = File.ReadAllBytes($"files/images/{image}");
        return file;
    }
}
