using System;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;

class Rocket {
    public Connection connection;
    public Vessel vessel;

    public double Head = 90;

    public Rocket()
    {
        Console.WriteLine("Zogera is in startup");
        connection = Program.connection;

    }
}
