using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
	public class TreeViewSample_VM
	{
		public string Greeting { get; private set; }

		private List<MusicAct> _topLevel = new List<MusicAct>();
		public List<MusicAct> TopLevel
		{
			get
			{
				return _topLevel;
			}
			private set
			{
				_topLevel = value;
			}
		}

		public TreeViewSample_VM()
		{
			Greeting = "Hello, world!";

			// Set up our "database" of music-related objects.
			MusicAct LedZ = new MusicAct("Led Zeppelin");
			Musician RobP = new Musician("Robert Plant", "Lead Singer");
			Musician JimP = new Musician("Jimmy Page", "Lead Guitar");
			LedZ.Members.Add(RobP);
			LedZ.Members.Add(JimP);
			MusicAct Rem = new MusicAct("R.E.M.");
			Musician MikeS = new Musician("Michael Stipe", "Lead Singer");
			Musician MikeM = new Musician("Mike Mills", "Bass Guitar");
			Rem.Members.Add(MikeS);
			Rem.Members.Add(MikeM);

			// Populate the top level Persons.
			_topLevel.Add(LedZ);
			_topLevel.Add(Rem);

			// Recursion test.
			MikeS.Acts.Add(Rem);

		}
	}

	public class Person_VM
	{
		private Musician myPerson;
		public Musician MyPerson
		{
			get
			{
				return myPerson;
			}
			set
			{
				myPerson = value;
			}
		}

		public Person_VM(Musician person)
		{
			MyPerson = person;
		}
	}

	public class Musician
	{
		public string Name { get; set; }
		public string Role { get; set; }

		private List<MusicAct> _acts = new List<MusicAct>();
		public List<MusicAct> Acts
		{
			get
			{
				return _acts;
			}

			private set
			{
				_acts = value;
			}
		}

		public Musician() : this("Unknown Comic", "Emcee") { }

		public Musician(string name, string role)
		{
			Name = name;
			Role = role;
		}
	}

	public class MusicAct
	{
		public string Name { get; set; }

		public List<Musician> Members { get; set; } = new List<Musician>();

		public MusicAct(string name)
		{
			Name = name;
		}
	}
}
