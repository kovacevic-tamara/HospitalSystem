

using bolnica.Service;
using Model.Director;
using Repository;
using System;
using System.Collections.Generic;
using System.Web.Management;

namespace Service
{
   public class RoomTypeService : IRoomTypeService
   {
        private readonly IRoomTypeRepository _repository;

        //private Repository.IRoomTypeRepository _roomTypeRepository;
        public IRoomService roomService;
        
        public RoomTypeService(IRoomTypeRepository repository, IRoomService roomService)
        {
            _repository = repository;
            this.roomService = roomService;
        }

        public bool CheckRoomTypeUnique(RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public void Delete(RoomType entity)
        {
            roomService.DeleteRoomsByRoomType(entity);
            _repository.Delete(entity);
        }


        public void Edit(RoomType entity)
        {
            _repository.Edit(entity);
        }

        public RoomType Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _repository.GetAll();
        }

        public RoomType Save(RoomType entity)
        {
            return _repository.Save(entity);
        }

    }
}