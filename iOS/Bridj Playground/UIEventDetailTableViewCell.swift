//
//  UIEventDetailTableViewCell.swift
//  Bridj Playground
//
//  Created by Jie Zhang on 13/11/18.
//  Copyright © 2018 Galaxy. All rights reserved.
//

import UIKit

class UIEventDetailTableViewCell: UITableViewCell {
    
    @IBOutlet weak var label_name: UILabel!
    @IBOutlet weak var label_venue: UILabel!
    @IBOutlet weak var label_price: UILabel!
    
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }

}
