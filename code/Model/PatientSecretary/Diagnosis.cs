using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Model.PatientSecretary
{
   public class Diagnosis : IIdentifiable<long>
   {
        public long Id;
        public string Name;
        public List<Symptom> Symptom;

        public Diagnosis(long id)
        {
            Id = id;
        }

        public Diagnosis(long id, string name) : this(id)
        {
            this.Name = name;
        }

        public Diagnosis(long id, string name, List<Symptom> symptom)
        {
            Id = id;
            this.Name = name;
            this.Symptom = symptom;
        }

        public long GetId()
        {
            return this.Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }

    }
}