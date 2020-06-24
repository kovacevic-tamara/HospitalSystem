﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;

namespace bolnica.Controller
{
    public interface IReportController
    {
        DoctorReportDTO GenerateAnamnesisPrescriptionReport(PatientFile patientFile);

        String GenerateRoomOccupationReport();

        SecretaryReportDTO GenerateDoctorOccupationReport(Doctor doctor, Period period);

        Therapy GenerateTherapyTimetableReport(PatientFile patientFile);
    }

}
