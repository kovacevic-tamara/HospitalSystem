﻿using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
   public class TherapyRepository : CSVRepository<Therapy, long>, ITherapyRepository
    {
        public TherapyRepository(ICSVStream<Therapy> stream, ISequencer<long> sequencer)
          : base(stream, sequencer)
        {

        }

        public IEnumerable<Therapy> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Therapy GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}