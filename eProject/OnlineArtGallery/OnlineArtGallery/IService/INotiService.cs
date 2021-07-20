using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineArtGallery.IService
{
    public interface INotiService
    {
        List<Notification> GetNotifications(int nToUserId, bool bIsOnlyUnread);
    }
}
