﻿using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    class HospitalizationCSVConverter : ICSVConverter<Hospitalization>
    {
        private readonly string _delimiter;

        public HospitalizationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        //long id, Period period, List<PatientFile> patientFile, Room room
        public Hospitalization ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Hospitalization hospitalization = new Hospitalization(long.Parse(tokens[0]),
                                    new Period(DateTime.Parse(tokens[1]), DateTime.Parse(tokens[2])),
                                    new PatientFile(long.Parse(tokens[3])), new Room(long.Parse(tokens[4])));
            return hospitalization;
        }

        public string ConvertEntityToCSVFormat(Hospitalization entity)
        {
            return string.Join(_delimiter, entity.Id, entity.Period.StartDate, entity.Period.EndDate, entity.PatientFile.GetId(), entity.Room.GetId());
        }
    }
}
