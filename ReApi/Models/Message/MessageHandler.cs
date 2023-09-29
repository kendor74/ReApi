namespace ReApi.Models.Message
{
    public class MessageHandler : IRepo<Messages, MessageDto>
    {
        private readonly ReDbContext _db;
        public MessageHandler(ReDbContext context)
        { 
          _db = context;
        }

        public async Task<Messages> Add(MessageDto DtoMessage)
        {
            var message = new Messages();
            if (DtoMessage is not null)
            {
                message.MessageDescription = DtoMessage.Message;
                message.Name = DtoMessage.Name;
                //Validate Email here
                message.Email = DtoMessage.Email;

                await _db.Messagess.AddAsync(message);
                await _db.SaveChangesAsync();
            }
            return message;
        }

        public async Task<bool> Delete(int id)
        {
            var message = await _db.Messagess.FindAsync(id);

            if (message is null)
                return false;
            _db.Messagess.Remove(message);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Messages>> GetAll()
        {
            return await _db.Messagess.ToListAsync();
        }

        public async Task<Messages> Update(MessageDto messageDto , int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Count()
        {
            return await _db.Messagess.CountAsync();
        }

        public async Task<Messages>? GetById(int entityId)
        {
            return await _db.Messagess.FindAsync(entityId);
        }

        public Task<Messages> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
