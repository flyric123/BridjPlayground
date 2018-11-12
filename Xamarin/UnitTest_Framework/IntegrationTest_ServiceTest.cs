using System;
using System.Threading.Tasks;
using Framework;
using Framework.ServiceImps;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_Framework
{
    [TestClass]
    public class IntegrationTest_ServiceTest
    {
        [TestMethod]
        public async Task TestMethod_TestEndPointCloudService_GetEventDetailFromCloud_All()
        {
            ServiceProvider.SetupServiceProvider(new TestEndPointCloudService());

            var all = await ServiceProvider.GetEventDetailsFromCloud_All();

            Assert.IsTrue(all.Count > 0);
        }

        [TestMethod]
        public async Task TestMethod_TestEndPointCloudService_GetEventDetailsFromCloud_HasSeats_OrderByTime()
        {
            ServiceProvider.SetupServiceProvider(new TestEndPointCloudService());

            var all = await ServiceProvider.GetEventDetailsFromCloud_All();

            var has_seats = await ServiceProvider.GetEventDetailsFromCloud_HasSeats_OrderByTime();

            Assert.IsTrue(has_seats.Count != 0 && has_seats.All(e => e.available_seats > 0));

            var no_seats = all.Where(e => has_seats.Any(he => he.name == e.name) == false).ToList();

            Assert.IsTrue(has_seats.Count == 0 || no_seats.All(e => e.available_seats == 0));

            Assert.IsTrue(has_seats.Count + no_seats.Count == all.Count);

            // verify time ordering
            var temp_date = DateTime.MinValue;
            for (int i = 0; i < has_seats.Count; ++i)
            {
                Assert.IsTrue(temp_date < has_seats[i].date);
                temp_date = has_seats[i].date;
            }
        }

        [TestMethod]
        public async Task TestMethod_TestEndPointCloudService_GetEventDetailsFromCloud_WithLabels_OrderByTime()
        {
            ServiceProvider.SetupServiceProvider(new TestEndPointCloudService());

            var with_one_label = await ServiceProvider.GetEventDetailsFromCloud_WithLabels_OrderByTime("ballet");

            Assert.IsTrue(with_one_label.Count == 1);

            var with_two_labels = await ServiceProvider.GetEventDetailsFromCloud_WithLabels_OrderByTime("play", "shakespeare");

            Assert.IsTrue(with_two_labels.Count == 2);

            // verify time ordering
            var temp_date = DateTime.MinValue;
            for (int i = 0; i < with_two_labels.Count; ++i)
            {
                Assert.IsTrue(temp_date < with_two_labels[i].date);
                temp_date = with_two_labels[i].date;
            }
        }
    }
}
