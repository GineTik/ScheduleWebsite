using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWebSite.Data.Repositories.Implemention
{
    public class BaseRepository<DB>
    {
        protected DB _db;

        public BaseRepository(DB db)
        {
            _db = db;
        }
    }
}
