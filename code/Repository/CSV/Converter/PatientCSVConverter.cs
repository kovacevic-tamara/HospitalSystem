﻿using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace bolnica.Repository.CSV.Converter
{
   public class PatientCSVConverter : ICSVConverter<Patient>
    {
        private readonly string _delimiter = ",";


        public Patient ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            try
            {
                string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
                Patient patient = new Patient(long.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], tokens[4], tokens[5],DateTime.Parse(tokens[6]) , null, tokens[8], tokens[9], null);
                patient.patientFile = new PatientFile(long.Parse(tokens[11]));
                patient.Guest = Boolean.Parse(tokens[12]);
                return patient;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
        public string ConvertEntityToCSVFormat(Patient entity)
        {
            //  entity.Image.Save("../../Images/" + entity.Username + ".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            return string.Join(_delimiter, entity.Id, entity.FirstName, entity.LastName, entity.Jmbg, entity.Email, entity.Phone, entity.DateOfBirth, null, entity.Username, entity.Password, null,entity.patientFile.GetId(), entity.Guest);
        }
    }
}
