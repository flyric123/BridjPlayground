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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel label_title_has_label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel label_title_has_seats { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView table_has_label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView table_has_seat { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (label_title_has_label != null) {
                label_title_has_label.Dispose ();
                label_title_has_label = null;
            }

            if (label_title_has_seats != null) {
                label_title_has_seats.Dispose ();
                label_title_has_seats = null;
            }

            if (table_has_label != null) {
                table_has_label.Dispose ();
                table_has_label = null;
            }

            if (table_has_seat != null) {
                table_has_seat.Dispose ();
                table_has_seat = null;
            }
        }
    }
}