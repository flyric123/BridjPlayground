//
//  Bridj_PlaygroundTests.swift
//  Bridj PlaygroundTests
//
//  Created by Jie Zhang on 13/11/18.
//  Copyright © 2018 Galaxy. All rights reserved.
//

import XCTest
@testable import Bridj_Playground

class Bridj_PlaygroundTests: XCTestCase {
    
    override func setUp() {
        super.setUp()
        // Put setup code here. This method is called before the invocation of each test method in the class.
    }
    
    override func tearDown() {
        // Put teardown code here. This method is called after the invocation of each test method in the class.
        super.tearDown()
    }
    
    func testExample() {
        // This is an example of a functional test case.
        // Use XCTAssert and related functions to verify your tests produce the correct results.
        
    }
    
    func testPerformanceExample() {
        // This is an example of a performance test case.
        self.measure {
            // Put the code you want to measure the time of here.
        }
    }
    
    func testEventDetailFuncs(){
        let event = EventDetail()
        event.available_seat = 100
        event.labels = ["a", "b", "c", "d"]
        
        XCTAssertTrue(event.HasSeats())
        XCTAssertTrue(event.HasLabels(target_labels: ["a"]))
        XCTAssertTrue(event.HasLabels(target_labels: ["b", "c"]))
        XCTAssertFalse(event.HasLabels(target_labels: ["r", "c"]))
    }
    
    func testEventDetailDataHandlerFuncs(){
        var events : Array<EventDetail> = []
        events.append(EventDetail())
        events[0].date = Date().addingTimeInterval(TimeInterval(10))
        events[0].available_seat = 10
        events[0].labels = ["a", "b", "c"]

        events.append(EventDetail())
        events[1].date = Date().addingTimeInterval(TimeInterval(2))
        events[1].available_seat = 0
        events[1].labels = ["b", "c"]
        
        events.append(EventDetail())
        events[2].date = Date().addingTimeInterval(TimeInterval(13))
        events[2].available_seat = 2
        events[2].labels = ["c", "e"]
        
        var filtered_event = EventDetailDataHandler.GetEventHasSeatsSortedByDate(events: events)
        XCTAssertTrue(filtered_event.count == 2)
        XCTAssertTrue(filtered_event[0].available_seat == 2)
        
        events.append(EventDetail())
        events[3].date = Date().addingTimeInterval(TimeInterval(20))
        events[3].available_seat = 5
        events[3].labels = ["e"]
        
        filtered_event = EventDetailDataHandler.GetEventHasSeatsAndLabelsSortedByDate(events: events, labels: ["e"])
        XCTAssertTrue(filtered_event.count == 2)
        XCTAssertTrue(filtered_event[0].available_seat == 5)
    }
}
