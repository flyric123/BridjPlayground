//
//  ViewController.swift
//  Bridj Playground
//
//  Created by Jie Zhang on 13/11/18.
//  Copyright © 2018 Galaxy. All rights reserved.
//

import UIKit

class ViewController: UIViewController, UITableViewDataSource, UITableViewDelegate {

    let cellID = "EventDetailCell"
    
    var dataSourceHasSeat : Array<EventDetail> = []
    var dataSourceHasLabels : Array<EventDetail> = []
    
    @IBOutlet var tableView : UITableView!
    
    func numberOfSections(in tableView: UITableView) -> Int {
        // we have 2 sections here
        // 0 - events has seats
        // 1 - events has seats and with label "play"
        return 2
    }
    
    func tableView(_ tableView: UITableView, titleForHeaderInSection section: Int) -> String? {
        return section == 0 ? "Events (has seats)" : "Events (labelled as play)"
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return section == 0 ? dataSourceHasSeat.count : dataSourceHasLabels.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell:UIEventDetailTableViewCell = tableView.dequeueReusableCell(withIdentifier: cellID) as! UIEventDetailTableViewCell
        
        let event : EventDetail = indexPath.section == 0 ? dataSourceHasSeat[indexPath.row] : dataSourceHasLabels[indexPath.row]
        
        cell.label_name.text = "Name: " + event.name
        cell.label_venue.text = "Venue: " + event.venue
        cell.label_price.text = "Price: " + String(event.price)
        
        return cell
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func viewWillAppear(_ animated: Bool) {
        // to-do: add a loading screen maybe?
        
        // when view appears, load data from cloud service
        CloudService.GetEventsFromCloud(
            completedHandler: {(data) in
                self.dataSourceHasSeat = EventDetailDataHandler.GetEventHasSeatsSortedByDate(events: data)
                self.dataSourceHasLabels = EventDetailDataHandler.GetEventHasSeatsAndLabelsSortedByDate(events: data, labels: ["play"])
                
                DispatchQueue.main.async{
                    self.tableView.reloadData()
                }
            },
            errorHandler: {(error) in
                DispatchQueue.main.async{
                    let dialog = UIAlertController(title: "Error!", message: error, preferredStyle: UIAlertControllerStyle.alert)
                    dialog.addAction(UIAlertAction(title: "Ok", style: UIAlertActionStyle.default, handler: nil))
                    self.present(dialog, animated: true, completion: nil)
                    
            }
        })
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
}

