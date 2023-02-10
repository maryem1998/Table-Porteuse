// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;



Console.WriteLine("Hello, World!");

//constructeur par défaut
Plane plane = new Plane();
plane.Capacity = 300;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Boing;
//Constructeur paramétré
//Plane plane2 = new Plane(PlaneType.Boing,new DateTime(2018,2,12),200);


//initialiseur d'objet 
Plane plane3 = new Plane
{
    Capacity = 100,
    ManufactureDate = DateTime.Now,
    PlaneType = PlaneType.Boing,
    PlaneId = 2
};

Passenger p1 = new Passenger
{
    FirstName= "Test",  
    LastName= "Test2",  
    BirthDate= new DateTime(1998-07-25)


};
Staff s1 = new Staff
{
    BirthDate = new DateTime(1998 - 07 - 25),
    FirstName = "Test",
    LastName = "Test",
};

Traveller t1 = new Traveller
{
    FirstName = "Test",
    LastName = "Test",

};
Console.WriteLine(p1.CheckProfile("Maryem", "Bouhlel"));
p1.PassengerType();
s1.PassengerType();
t1.PassengerType();
ServiceFlight sf = new ServiceFlight();
sf.Flights = TestData.listFlights;
foreach (var item in sf.GetFlightDates("Madrid")  )
{
    Console.WriteLine(item);
}


sf.DestinationGroupedFlights();
sf.ShowFlightDetails(TestData.BoingPlane);




