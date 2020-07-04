using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI_birras.Infrastructure;
using webAPI_birras.Models;

namespace webAPI_birras.Services
{
    public class NotificationService
    {
        private readonly IMongoCollection<Notification> _Notifications;

        public NotificationService(IBirrasDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Notifications = database.GetCollection<Notification>(settings.NotificationsCollectionName);
        }

        public List<Notification> Get() =>
            _Notifications.Find(Notification => true).ToList();

        public Notification Get(string id) =>
            _Notifications.Find<Notification>(Notification => Notification.Id == id).FirstOrDefault();

        public Notification Create(Notification Notification)
        {
            _Notifications.InsertOne(Notification);
            return Notification;
        }

        public void Update(string id, Notification NotificationIn) =>
            _Notifications.ReplaceOne(Notification => Notification.Id == id, NotificationIn);

        public void Remove(Notification NotificationIn) =>
            _Notifications.DeleteOne(Notification => Notification.Id == NotificationIn.Id);

        public void Remove(string id) =>
            _Notifications.DeleteOne(Notification => Notification.Id == id);
    }
}

