# Android
This is the native Android app written in Java with Android Studio

This app will fetch event data from the API at "https://s3-ap-southeast-2.amazonaws.com/bridj-coding-challenge/events.json" 

After the data is fetched, the app will do the following:
- events with no seat will be removed from the list
- the remaining events will be displayed in descending order of event date
- the events (in the remaining event list) with label "play" will be displayed in descending order of event date
- events will be displayed in the following format: name, venue and price

Some backend code is unit tested.