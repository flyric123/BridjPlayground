//
//  EventDetailDataHandler.swift
//  Bridj Playground
//
//  Created by Ric Zhang on 26/11/18.
//  Copyright © 2018 Galaxy. All rights reserved.
//

import Foundation

/// helper class to handle event detail arrays
class EventDetailDataHandler
{
    /// function to order the event by descending order and filter out those event does not have seats
    static func GetEventHasSeatsSortedByDate(events : Array<EventDetail>) -> Array<EventDetail>{
        return events.sorted{$0.date > $1.date}.filter{$0.HasSeats()}
    }
    
    /// function to order the event by descending order, filter out those event does not have seats and with labels
    static func GetEventHasSeatsAndLabelsSortedByDate(events : Array<EventDetail>, labels: Array<String>) -> Array<EventDetail> {
        return events.sorted{$0.date > $1.date}.filter{$0.HasSeats()}.filter{$0.HasLabels(target_labels: labels)}
    }
}
