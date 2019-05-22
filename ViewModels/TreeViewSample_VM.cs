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

		public List<MusicAct> MusicActs { get; set; }
		public List<Musician> Musicians { get; set; }

		private List<MusicAct_VM> _topLevel = new List<MusicAct_VM>();
		public List<MusicAct_VM> TopLevel
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

		private List<Musician_VM> MusicianVMs = new List<Musician_VM>();

		public TreeViewSample_VM()
		{
			Greeting = "Hello, world!";

			// Set up our "database" of music-related objects.
			Musician RobP = new Musician("Robert Plant", "Lead Singer");
			Musician JimP = new Musician("Jimmy Page", "Lead Guitar");
			Musician MikeS = new Musician("Michael Stipe", "Lead Singer");
			Musician MikeM = new Musician("Mike Mills", "Bass Guitar");

			MusicAct LedZ = new MusicAct("Led Zeppelin");
			LedZ.Members.Add(RobP);
			LedZ.Members.Add(JimP);
			MusicAct Rem = new MusicAct("R.E.M.");
			Rem.Members.Add(MikeS);
			Rem.Members.Add(MikeM);
			MusicAct HoneyD = new MusicAct("The Honeydrippers");
			HoneyD.Members.Add(RobP);

			RobP.Acts.Add(LedZ);
			RobP.Acts.Add(HoneyD);
			JimP.Acts.Add(LedZ);
			MikeS.Acts.Add(Rem);
			MikeM.Acts.Add(Rem);

			// I use VMs as list elements, but if there were a real database I would
			// have a list for each Model class. Emulate that here.
			MusicActs = new List<MusicAct>
			{
				LedZ,
				Rem,
				HoneyD,
			};
			Musicians = new List<Musician>
			{
				RobP,
				JimP,
				MikeS,
				MikeM,
			};

			//
			// Prepare the ViewModels
			//

			// Create a VM for each musician.
			MusicianVMs.Add(new Musician_VM(RobP));
			MusicianVMs.Add(new Musician_VM(JimP));
			MusicianVMs.Add(new Musician_VM(MikeS));
			MusicianVMs.Add(new Musician_VM(MikeM));

			// Create a VM for each act.
			_topLevel.Add(new MusicAct_VM(LedZ, MusicianVMs));
			_topLevel.Add(new MusicAct_VM(Rem, MusicianVMs));
			_topLevel.Add(new MusicAct_VM(HoneyD, MusicianVMs));
		}
	}

	public class MusicAct_VM
	{
		private MusicAct _theMusicAct;
		public MusicAct TheMusicAct
		{
			get
			{
				return _theMusicAct;
			}
			set
			{
				_theMusicAct = value;
			}
		}

		private List<Musician_VM> _theMusicians = new List<Musician_VM>();
		public List<Musician_VM> TheMusicians
		{
			get
			{
				return _theMusicians;
			}

			set
			{
			}
		}

		public int NumMembers
		{
			get
			{
				return _theMusicians.Count;
			}
			set
			{

			}
		}

		public MusicAct_VM(MusicAct act, List<Musician_VM> musicianVms)
		{
			_theMusicAct = act;

			// Create the musicians list.
			if (musicianVms == null)
			{
				foreach (Musician m in _theMusicAct.Members)
				{
					Musician_VM mvm = new Musician_VM(m);
					_theMusicians.Add(mvm);
				}
			}
			else
			{
				foreach (Musician m in _theMusicAct.Members)
				{
					// Find the corresponding VM.
					Musician_VM mvm = musicianVms.Find(vm => vm.MyPerson == m);

					// Add the Musician_VM to our list.
					_theMusicians.Add(mvm);

					// Add us to the musician's list of MusicAct_VMs.
					mvm.MyActs.Add(this);
				}
			}
		}
	}

	public class Musician_VM
	{
		private Musician _myPerson;
		public Musician MyPerson
		{
			get
			{
				return _myPerson;
			}
			set
			{
				_myPerson = value;
			}
		}

		private List<MusicAct_VM> _myActs = new List<MusicAct_VM>();
		public List<MusicAct_VM> MyActs
		{
			get
			{
				return _myActs;
			}
			set
			{

			}
		}

		public Musician_VM(Musician person)
		{
			_myPerson = person;

#if false
			// Create the acts list.
			foreach (MusicAct act in _myPerson.Acts)
			{
				MusicAct_VM mavm = new MusicAct_VM(act);
				_myActs.Add(mavm);
			}
#endif
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
