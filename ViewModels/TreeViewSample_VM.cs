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

		private List<Person> _topLevel = new List<Person>();
		public List<Person> TopLevel
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

			// Set up our "database" of Person objects.
			Person LedZ = new Person("Led Zeppelin");
			Person RobP = new Person("Robert Plant");
			Person JimP = new Person("Jimmy Page");
			LedZ.Children.Add(RobP);
			LedZ.Children.Add(JimP);
			Person Rem = new Person("R.E.M.");
			Person MikeS = new Person("Michael Stipe");
			Person MikeM = new Person("Mike Mills");
			Rem.Children.Add(MikeS);
			Rem.Children.Add(MikeM);

			// Populate the top level Persons.
			_topLevel.Add(LedZ);
			_topLevel.Add(Rem);

			// Recursion test.
			MikeS.Children.Add(Rem);

		}
	}

	public class Person_VM
	{
		private Person myPerson;
		public Person MyPerson
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

		public Person_VM(Person person)
		{
			MyPerson = person;
		}
	}

	public class Person
	{
		public string Name { get; set; }

		private List<Person> _children = new List<Person>();
		public List<Person> Children
		{
			get
			{
				return _children;
			}

			private set
			{
				_children = value;
			}
		}

		public Person()
		{
			Name = "Unknown Comic";
		}

		public Person(string name)
		{
			Name = name;
		}
	}
}
