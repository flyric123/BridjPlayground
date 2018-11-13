//
//  EventDetail.swift
//  Bridj Playground
//
//  Created by Jie Zhang on 13/11/18.
//  Copyright © 2018 Galaxy. All rights reserved.
//

import UIKit

// the class contains all data for a event
class EventDetail: NSObject
{
    var name : String = ""
    var venue : String = ""
    var price : Float = 0
    var available_seat : Int = 0
    var date : Date = Date()
    var labels : [String] = []
    
}
