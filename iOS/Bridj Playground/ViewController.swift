//
//  ViewController.swift
//  Bridj Playground
//
//  Created by Jie Zhang on 13/11/18.
//  Copyright © 2018 Galaxy. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    
    
    @IBOutlet weak var tableview_has_seat : UITableView!
    @IBOutlet weak var tableview_with_labels : UITableView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func viewWillAppear(_ animated: Bool) {
        CloudService.GetEventsFromCloud(completedHandler: {(data) in
            let temp : Int = 0
        })
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }


}

