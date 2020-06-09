﻿using bolnica.Model.Dto;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
   public class DatePrioritySearch : ISearchPeriods
    {
        public DatePrioritySearch() { }

        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO, List<BusinessDay> businessDayCollection)
        {
            List<BusinessDay> IterationDays = DaysForExactPeriod(businessDayDTO.Period, businessDayDTO.Doctor.BusinessDay);
            foreach (BusinessDay day in IterationDays)
            {
                List<ExaminationDTO> examinationDTOCollection = CreateExaminationDTO(day);
                if (examinationDTOCollection != null)
                {
                    return examinationDTOCollection;
                }
            }
            return AlternativeForDoctor(businessDayDTO, businessDayCollection.Except(IterationDays));
        }

        private List<ExaminationDTO> AlternativeForDoctor(BusinessDayDTO businessDayDTO, IEnumerable<BusinessDay> businessDayCollection)
        {
            foreach(BusinessDay day in businessDayCollection.ToList())
            {
                if (day.Shift.EndDate >= businessDayDTO.Period.StartDate && day.Shift.EndDate <= businessDayDTO.Period.EndDate) {

                    List<ExaminationDTO> examinationDTOCollection = CreateExaminationDTO(day);
                    if (examinationDTOCollection != null)
                    {
                        return examinationDTOCollection;

                    }
                }
            }
            return null;
        }

        public List<ExaminationDTO> CreateExaminationDTO(BusinessDay businessDay)
        {
            List<ExaminationDTO> retVal = new List<ExaminationDTO>();
            DateTime Start = businessDay.Shift.StartDate;
            DateTime End = Start.AddMinutes(BusinessDayService.durationOfExamination);
            while (End <= businessDay.Shift.EndDate)
            {
                if (!businessDay.ScheduledPeriods.Any(item => item == new Period(Start, End)))
                {
                    ExaminationDTO examinationDTO = new ExaminationDTO
                    {
                        Room = businessDay.room,
                        Period = new Period(Start, End),
                        Doctor = businessDay.doctor
                    };
                    retVal.Add(examinationDTO);
                    return retVal;
                }

            }
            return null;
        }


        public List<BusinessDay> DaysForExactPeriod(Period period, List<BusinessDay> businessDaysCollection)
        {
            List<BusinessDay> businessDays = new List<BusinessDay>();
            foreach (BusinessDay day in businessDaysCollection)
            {
                if (day.Shift.StartDate.Date >= period.StartDate.Date && day.Shift.EndDate.Date <= period.EndDate.Date)
                {
                    businessDays.Add(day);
                }
            }

            return businessDays;
        }


    }
}