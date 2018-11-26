//
//  EventDetail.swift
//  Bridj Playground
//
//  Created by Jie Zhang on 13/11/18.
//  Copyright © 2018 Galaxy. All rights reserved.
//

import UIKit

/// the class contains all data for a event
class EventDetail: NSObject
{
    var name : String = ""
    var venue : String = ""
    var price : Float = 0
    var available_seat : Int = 0
    var date : Date = Date()
    var labels : Array<String> = []
    
    /// function to check if this event has seats left
    func HasSeats () -> Bool{
        return available_seat > 0
    }
    
    /// function to check if this event has a set of labels
    func HasLabels (target_labels : Array<String>) -> Bool{
        let label_set = Set(labels)
        let target_set = Set(target_labels)
        return target_set.isSubset(of: label_set)
    }
}
