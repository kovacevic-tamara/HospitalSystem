/***********************************************************************
 * Module:  IExaminationPreviousRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IExaminationPreviousRepository
 ***********************************************************************/

using System;

namespace Repository
{
   public interface IExaminationPreviousRepository
   {
      Examination SaveExamination(Examination examination);
      Examination[] GetExaminationsByUser(User user);
      Boolean DeleteExamination(Examination examination);
      Examination[] GetExaminations();
   }
}