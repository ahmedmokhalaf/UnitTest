using App;

WeightCalculator weightCalculator = new WeightCalculator(null, 180, 'm');
Console.WriteLine(weightCalculator.GetIdealBodyWeight(weightCalculator.Gander.Value, weightCalculator.Height.Value));

User a = new User { Email = "a@a.aaa", Name = "hh", BirthDate = new DateTime(1991, 12, 12) };
AccessLayer weightContext = new AccessLayer(new WeightContext());
try
{

    User user = new User
    {
        Name = "Ahmed",
        Email = "a@a.a",
        BirthDate = new DateTime(1991, 12, 12)
    };

    AccessLayer access = new AccessLayer(new WeightContext());
    access.AddUser(user);
    User userToFind = access.GetUser("Ahmed");
    //   weightContext.AddUser(a);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.ReadKey();

