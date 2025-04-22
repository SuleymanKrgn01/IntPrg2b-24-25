using Site1.Models;

namespace Site1.Data
{
    public class MockData
    {

        public static List<Person> PersonList { get; set; } = new List<Person> {
            new Person{
                Id=1,
                Name="Ali",
                Lastname="YAMAN",
                BirthPlace="Ankara"
            },
            new Person{
                Id=2,
                Name="Ayşe",
                Lastname="TAŞ",
                BirthPlace="İzmir"
            },
            new Person{
                Id=3,
                Name="Ahmet",
                Lastname="HAK",
                BirthPlace="İstanbul"
            },
            new Person{
                Id=4,
                Name="Fatma",
                Lastname="IŞIK",
                BirthPlace="Antalya"
            },
        };




    }
}
