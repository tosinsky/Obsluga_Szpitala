namespace _2021L_PAIM_Lab.App
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;
    using _2021L_PAIM_Lab.ClassLibrary;


    public class Program1
    {
        public static void Main(string[] args)
        {
            IPersonRepository PersonRepository = new PersonRepository() as IPersonRepository;

            Debug.Assert(condition: PersonRepository != null);

            foreach (Person person in PersonRepository.Find(PersonSex.Male))
            {
                string shapeDescription = person.GetDescription();
                double shapeArea = person.GetArea();

                Console.WriteLine("person description = {0}; person area = {1}", shapeDescription, shapeArea);
            }
            Console.ReadLine();
        }
    }
}
