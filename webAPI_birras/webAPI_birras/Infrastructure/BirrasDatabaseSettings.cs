using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Infrastructure
{
    public class BirrasDatabaseSettings : IBirrasDatabaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string MeetUpsCollectionName { get; set; }
        public string NotificationsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBirrasDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string MeetUpsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string NotificationsCollectionName { get; }
    }
}
