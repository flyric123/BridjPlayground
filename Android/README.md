# Android
This is the native Android app written in Java with Android Studio

This app will fetch event data from the API at "https://s3-ap-southeast-2.amazonaws.com/bridj-coding-challenge/events.json" 

After the data is fetched, the app will do the following:
- events with no seat will be removed from the list
- the remaining events will be displayed in descending order of event date
- the events (in the remaining event list) with label "play" will be displayed in descending order of event date
- events will be displayed in the following format: name, venue and price

Unit-test has been written just for the sorting and filtering mechanics, which could be found in ExampleUnitTest.java file.

Additionally, a simple layout template was implemented to display the details of events. The template xml file could be found at temp_event_item.xml

Last but not least, most of the layout files are shared between Xamarin Android project and this Native Android project.