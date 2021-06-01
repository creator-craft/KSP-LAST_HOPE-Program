using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using System;
using System.Threading;

class Hopper {

	public static readonly double G = 6.674E10;

	public double distance(Tuple<double, double, double> p1, Tuple<double, double, double> p2) {
		return Math.Sqrt((p2.Item1-p1.Item1)*(p2.Item1-p1.Item1) + (p2.Item2 - p1.Item2) * (p2.Item2 - p1.Item2) + (p2.Item3 - p1.Item3) * (p2.Item3 - p1.Item3));
	}


	public Connection connection;
	public Vessel hopper;


	public double Head = 90;

	public Hopper(Connection conn) {

		Console.WriteLine("Hopper is in startup");
		connection = conn;

		hopper = connection.SpaceCenter().ActiveVessel;

		// Juste pour tester:
		CelestialBody Planet = hopper.Orbit.Body;
		double d = distance(Planet.Position(Planet.ReferenceFrame), hopper.Position(Planet.ReferenceFrame));
		double force_P = G * Planet.Mass * hopper.Mass / (d * d);
		Console.WriteLine("Poids: " + force_P);
		Console.WriteLine("g: " + force_P / hopper.Mass);

		// Tourne le vaisseau
		hopper.Control.Pitch = 85f / 90f;

		// Calcule la pousser requise pour être en vol stationnaire:
		float thrust = CalculateRequiredPower(force_P, hopper.AutoPilot.TargetPitch) / hopper.AvailableThrust; // OR: hopper.Control.Pitch * 90
		Console.WriteLine("Pousser: " + thrust);

		if( thrust > 1 ) {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("ERREUR: POUSSER INSSUFISANTE -> " + thrust + " N pour un maximum de -> " + hopper.AvailableThrust + " N.");
			Console.ResetColor();
			return;
		}

		//Vol stationnaire pour TargetPitch=90 et décalage vers le côté sinon
		hopper.Control.Throttle = thrust;


	   /* hopper.Control.Throttle = 1;
		hopper.AutoPilot.Engage();
		hopper.AutoPilot.TargetPitchAndHeading(90, (float)Head);
		hopper.Control.ActivateNextStage();

		Thread.Sleep(3000);

		hopper.Control.ActivateNextStage();

		Console.WriteLine("Liftoff");*/
		
	}

	/* Poids: en N
	 * angle en °
	 * return: Force in N
	 */
	public float CalculateRequiredPower(double P, double angle) {
		CelestialBody Planet = hopper.Orbit.Body;

		double d = distance(Planet.Position(Planet.ReferenceFrame), hopper.Position(Planet.ReferenceFrame));

		double force_P = G * Planet.Mass * hopper.Mass / (d * d);

		return (float)(P / Math.Cos(angle * Math.PI / 180d));//IF -1<=angle<=1 : angle * Math.PI / 2d
	}

}
