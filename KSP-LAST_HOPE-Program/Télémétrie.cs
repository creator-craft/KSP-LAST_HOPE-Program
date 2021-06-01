using System;
using System.Threading;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;

class Télémétrie {

	public static void Tele() {

		/*Flight telemetrie = Program.rocket.vessel.Flight();
		
		while (true) {
			Console.WriteLine("#---------------#\nvessel name: " + Program.rocket.vessel.Name);
			Console.WriteLine("Mass: " + Program.rocket.vessel.Mass + " kg");
			Console.WriteLine("Altitude: " + telemetrie.SurfaceAltitude + " m");
			Console.WriteLine("Latitude: " + telemetrie.Longitude + "°");
			Console.WriteLine("Longitude: " + telemetrie.Latitude + "°");
			Console.Write("Velocity: ");
			Print(telemetrie.Velocity);
			Console.WriteLine("\nSpeed: " + telemetrie.TrueAirSpeed * 3.6 + " m.s⁻¹");
			Console.Write("Center of Mass: ");
			Print(telemetrie.CenterOfMass);
			Console.Write("\nDirection: ");
			Print(telemetrie.Direction);
			Console.WriteLine("\nAtmosphere density: " + telemetrie.AtmosphereDensity + " kg.m⁻³");
			Console.WriteLine("Pressure: " + telemetrie.StaticPressure + " Pa");
			Console.WriteLine("Temperature: " + (telemetrie.StaticAirTemperature - 273.15) + "°C");
			Console.WriteLine("\n#---------------#");

			Thread.Sleep(250);
		}*/
	}

	public static void Print(Tuple<double, double, double> obj) {
		Console.Write("[" + obj.Item1 + ", " + obj.Item2 +", " + obj.Item3 + "]");
	}

}
