# iOS
This is the native iOS app written in Swift

This app will fetch event data from the API at "https://s3-ap-southeast-2.amazonaws.com/bridj-coding-challenge/events.json" 

After the data is fetched, the app will do the following:
- events with no seat will be removed from the list
- the remaining events will be displayed in descending order of event date
- the events (in the remaining event list) with label "play" will be displayed in descending order of event date
- events will be displayed in the following format: name, venue and price

Unit-test has been written just for the sorting and filtering mechanics, which could be found in Bridj_PlaygroundTests.swift file.

The iOS app UI to display the event details is just the TableView. 