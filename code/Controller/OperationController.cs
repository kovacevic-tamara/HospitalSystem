using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class OperationController : IOperationController
    {
        private IOperationService _service;

        public OperationController(IOperationService service)
        {
            _service = service;
        }

        public void Delete(Operation entity)
        {
            _service.Delete(entity);
        }

        public void Edit(Operation entity)
        {
            _service.Edit(entity);
        }

        public Operation Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return _service.GetAll();
        }

        public Operation Save(Operation entity)
        {
            return _service.Save(entity);
        }
    }
}