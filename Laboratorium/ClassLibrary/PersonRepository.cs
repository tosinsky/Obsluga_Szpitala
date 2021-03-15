namespace _2021L_PAIM_Lab.Laboratorium.ClassLibrary
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;





    public class PersonRepository : IPersonRepository
    {
        private readonly Person[] persons = new Person[]
        {
      new Doctor( "Marek Eugeniusz", 1.0) { Sex = PersonSex.Male },
      new Patient( "Elżbieta Froncz", 2.0, 1.0 ) { Sex = PersonSex.Female },
      new Patient( "Darek Lebenga", 1.0, 2.0 ) { Sex = PersonSex.Male }
        };

        public Person[] Find(PersonSex Sex)
        {
            IList<Person> foundPersons = persons.Where(s => s.Sex == Sex).ToList();

            return foundPersons.ToArray();
        }
    }
}