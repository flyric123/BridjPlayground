// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Blank
{
    [Register ("EventDetailTableCell")]
    partial class EventDetailTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel label_name { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel label_price { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel label_venue { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (label_name != null) {
                label_name.Dispose ();
                label_name = null;
            }

            if (label_price != null) {
                label_price.Dispose ();
                label_price = null;
            }

            if (label_venue != null) {
                label_venue.Dispose ();
                label_venue = null;
            }
        }
    }
}