using Foundation;
using Framework.Datas;
using System;
using UIKit;

namespace Blank
{
    /// <summary>
    /// the table cell class for the table view displaying the event details
    /// </summary>
    public partial class EventDetailTableCell : UITableViewCell
    {
        public EventDetailTableCell (IntPtr handle) : base (handle)
        {
        }

        /// <summary>
        /// function to populate the UI with data
        /// </summary>
        /// <param name="obj"></param>
        public void SetupCell(EventDetail obj)
        {
            label_name.Text = $"Name: {obj.name}";
            label_price.Text = $"Price: {obj.price:F1}";
            label_venue.Text = $"Venue: {obj.venue}";
        }
    }
}