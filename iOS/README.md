# iOS
This is the native iOS app written in Swift

This app will fetch event data from the API at "https://s3-ap-southeast-2.amazonaws.com/bridj-coding-challenge/events.json" 

After the data is fetched, the event data will be displayed as:
- events with no seat will be removed from the list
- the remaining events will be displayed in decending order of event date
- the events (in the remaining event list) with label "play" will be displayed in decending order of event date
- events will be displayed in the following format: name, venue and price
