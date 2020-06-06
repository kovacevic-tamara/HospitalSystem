/***********************************************************************
 * Module:  Referral.cs
 * Author:  Asus
 * Purpose: Definition of the Class Doctor.Referral
 ***********************************************************************/

using Model.PatientSecretary;
using Repository;
using System;

namespace Model.Doctor
{
   public class Referral : IIdentifiable<long>
   {

        public long Id;
        public DateTime Date;
        public DateTime ExpirationDate;
        public Model.Users.Doctor Doctor;


        public Referral(long id)
        {
            Id = id;
        }

        public Referral(long id,DateTime date, DateTime expirationDate, Users.Doctor doctor)
        {
            Date = date;
            ExpirationDate = expirationDate;
            this.Doctor = doctor;
            Id = id;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}