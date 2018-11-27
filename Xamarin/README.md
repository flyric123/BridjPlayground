# Xamarin
This is the Xamarin app written in C# and Xamarin Native framework

This app will fetch event data from the API at "https://s3-ap-southeast-2.amazonaws.com/bridj-coding-challenge/events.json" 

After the data is fetched, the app will do the following:
- events with no seat will be removed from the list
- the remaining events will be displayed in ascending order of event date
- the events (in the remaining event list) with label "play" will be displayed in ascending order of event date
- events will be displayed in the following format: name, venue and price

Unit-Test and Integration test has been implemented for this project, which could be found in IntegrationTest_ServiceTest.cs file

Noted: Most of the layout files are shared between this Xamarin Android project and Native Android project.