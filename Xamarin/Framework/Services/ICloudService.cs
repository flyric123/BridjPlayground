using Framework.Datas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Services
{
    public interface ICloudService
    {
        /// <summary>
        /// function to get a list of event details from cloud end point
        /// </summary>
        /// <returns></returns>
        Task<List<EventDetail>> GetEventDetails();
    }
}
