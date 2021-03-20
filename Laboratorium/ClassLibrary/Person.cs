namespace _2021L_PAIM_Lab.Laboratorium.ClassLibrary
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;


    public abstract class Person
    {
        #region Properties and Fields

        public PersonSex Sex { get; set; }

        public string Name
        {
            get { return this.name; }

            internal set
            {
                Debug.Assert(condition: !String.IsNullOrWhiteSpace(value));

                this.name = value;
            }
        }

        private string name;

        #endregion

        #region Constructors

        public Person(string name)
        {
            this.Name = name;
        }

        #endregion

        #region Methods

        public virtual string GetDescription()
        {
            return String.Format("{0} of Sex {1}", this.Name, this.Sex);
        }



        #endregion
    }
}