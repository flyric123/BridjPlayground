using Framework.Datas;
using Framework.Services;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public static class ServiceProvider
    {
        private static ICloudService _cloud_service;

        /// <summary>
        /// function to setup all dependencies for the service provider
        /// </summary>
        public static void SetupServiceProvider(ICloudService cloud_service)
        {
            _cloud_service = cloud_service;
        }

        /// <summary>
        /// function to get all event details from a cloud service
        /// </summary>
        /// <returns></returns>
        public static async Task<List<EventDetail>> GetEventDetailsFromCloud_All ()
        {
            return await _cloud_service.GetEventDetails();
        }

        /// <summary>
        /// function to get the event details from a cloud service, which has seats and order by time
        /// </summary>
        /// <returns></returns>
        public static async Task<List<EventDetail>> GetEventDetailsFromCloud_HasSeats_OrderByTime()
        {
            var all = await _cloud_service.GetEventDetails();
            return all.Where(e => e.available_seats > 0).OrderBy(e => e.date).ToList();
        }

        /// <summary>
        /// function to get the event details from a cloud service, which has some certain labels and order by time
        /// </summary>
        /// <returns></returns>
        public static async Task<List<EventDetail>> GetEventDetailsFromCloud_WithLabels_OrderByTime(params string[] labels)
        {
            var all = await _cloud_service.GetEventDetails();
            return all.Where(e => labels.All(target => e.labels.Any(l => l == target))).OrderBy(e => e.date).ToList();
        }
    }
}
