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
        CloudService.GetEventsFromCloud()
    }
    
    func testPerformanceExample() {
        // This is an example of a performance test case.
        self.measure {
            // Put the code you want to measure the time of here.
        }
    }
    
}
