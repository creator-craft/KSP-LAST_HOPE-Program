using System;
using KRPC.Client;
using System.Net;
using KRPC.Client.Services.KRPC;


class Program {

    //public static Rocket rocket;
    public static Connection connection;

    static void Main(string[] args) {

        connection = new Connection(name: "Rocket Computer", address: IPAddress.Parse("127.0.0.1"), rpcPort: 50000, streamPort: 50001);

        var krpc = connection.KRPC();

        foreach (var a in krpc.Clients)
        {
            Console.WriteLine(a.Item2 + " " + a.Item3);
        }

        Hopper vessel = new Hopper(connection);

        //rocket = new Rocket();

        //Télémétrie.Tele();

        connection.Dispose();

    }
}
