//
//  CloudService.swift
//  Bridj Playground
//
//  Created by Jie Zhang on 13/11/18.
//  Copyright © 2018 Galaxy. All rights reserved.
//

import Foundation

class CloudService
{
    static var end_point_url : String = "https://s3-ap-southeast-2.amazonaws.com/bridj-coding-challenge/events.json"
    
    static func GetEventsFromCloud(completedHandler: @escaping (_ received_data: Array<EventDetail>) -> Void)
    {
        if let url = URL(string: end_point_url){
            var request : URLRequest = URLRequest(url: url)
            request.httpMethod = "GET"
            
            var data_task = URLSession.shared.dataTask(with: request, completionHandler: {(data, response, error) in
                    guard error == nil else {
                        print("get error while having data from cloud")
                        return
                    }
                    
                    guard let content = data else {
                        print ("No data!")
                        return
                    }
                    
                guard let json = (try? JSONSerialization.jsonObject(with: content, options: JSONSerialization.ReadingOptions.mutableContainers)) as? [String : Any] else
                    {
                        print ("Not containing JSON")
                        return
                    }

                //print(json["events"])
                
                var temp : Array<EventDetail> = json["events"] as! Array<EventDetail>
                
                var events : Array<EventDetail> = []
                let dateFormatter = DateFormatter()
                dateFormatter.timeZone = TimeZone.autoupdatingCurrent
                dateFormatter.dateFormat = "yyyy-MM-dd'T'HH:mm:ssZ"
                
                if json["events"] is Array<AnyObject> {
                    for jobj in json["events"] as! Array<AnyObject> {
                        var event : EventDetail = EventDetail()
                        event.available_seat = (jobj["available_seats"] as AnyObject? as? Int) ?? 0
                        event.price = (jobj["price"] as AnyObject? as? Float) ?? 0
                        event.venue = (jobj["venue"] as AnyObject? as? String) ?? ""
                        event.name = (jobj["name"] as AnyObject? as? String) ?? ""
                        event.labels = jobj["labels"] as! [String]
                        guard let date = dateFormatter.date(from:(jobj["date"] as AnyObject? as? String) ?? "") else
                        {
                            print("Invalid date")
                            return
                        }
                        event.date = date;
                        
                        events.append(event)
                    }
                    
                    completedHandler(events)
                }
            })
            
            data_task.resume()
            
        }
    }
}
