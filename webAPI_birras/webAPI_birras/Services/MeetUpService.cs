using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_birras.Infrastructure;
using webAPI_birras.Models;

namespace webAPI_birras.Services
{
    public class MeetUpService
    {
        private readonly IMongoCollection<MeetUp> _MeetUps;

        public MeetUpService(IBirrasDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _MeetUps = database.GetCollection<MeetUp>(settings.MeetUpsCollectionName);
        }

        public List<MeetUp> Get() =>
            _MeetUps.Find(MeetUp => true).ToList();

        public MeetUp Get(string id) =>
            _MeetUps.Find<MeetUp>(MeetUp => MeetUp.Id == id).FirstOrDefault();

        public MeetUp Create(MeetUp MeetUp)
        {
            _MeetUps.InsertOne(MeetUp);
            return MeetUp;
        }

        public void Update(string id, MeetUp MeetUpIn) =>
            _MeetUps.ReplaceOne(MeetUp => MeetUp.Id == id, MeetUpIn);

        public void Remove(MeetUp MeetUpIn) =>
            _MeetUps.DeleteOne(MeetUp => MeetUp.Id == MeetUpIn.Id);

        public void Remove(string id) =>
            _MeetUps.DeleteOne(MeetUp => MeetUp.Id == id);

    }
}
