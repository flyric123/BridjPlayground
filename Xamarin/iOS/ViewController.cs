using Foundation;
using Framework;
using Framework.Datas;
using System;
using System.Collections.Generic;
using UIKit;

namespace Blank
{
    public partial class ViewController : UIViewController
    {
        /// <summary>
        /// the data source class for the table
        /// </summary>
        private class EventTableDataSource : UITableViewDataSource
        {
            private const string const_string_cell_name = "EventDetailTableCell";

            private List<EventDetail> BufferedEventDetailList { get; set; }

            public EventTableDataSource (List<EventDetail> list)
            {
                BufferedEventDetailList = list;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                EventDetailTableCell cell = (EventDetailTableCell)tableView.DequeueReusableCell(const_string_cell_name);

                cell.SetupCell(BufferedEventDetailList[indexPath.Row]);

                return cell;
            }

            public override nint RowsInSection(UITableView tableView, nint section)
            {
                return BufferedEventDetailList.Count;
            }
        }

        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            LoadView();
        }

        /// <summary>
        /// function to load data from cloud and show to user
        /// </summary>
        private async void LoadView()
        {
            // TODO: maybe a simple loading UI here?

            // NOTE: maybe worthy to have only one read from cloud then filter the data here
            // if the loading from cloud would take too long
            var list_has_seat = await ServiceProvider.GetEventDetailsFromCloud_HasSeats_OrderByTime();
            var list_with_label = await ServiceProvider.GetEventDetailsFromCloud_WithLabels_OrderByTime("play");

            InvokeOnMainThread(() =>
            {
                table_has_seat.DataSource = new EventTableDataSource(list_has_seat);
                table_has_label.DataSource = new EventTableDataSource(list_with_label);

                table_has_seat.ReloadData();
                table_has_label.ReloadData();
            });
        }
    }
}