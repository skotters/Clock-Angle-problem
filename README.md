# Clock-Angle-problem
Just my attempt at the clock-angle problem I heard about in a virtual call months ago.

The program provides the angle between the hour hand and minute hand on a clock, given a certain time. Additionally, I threw in the seconds hand which added more precision to the angle.

How I approached this problem...

* A circle has 360 degrees.
* The seconds hand has 60 'tics' to do a full revolution
* The minute hand has 60 * 60 = 3600 tics to do a full revolution
* The hour hand has 60 * 60 * 12 = 43200 tics to do a full revolution

Sample time entry 5 hours, 27 minutes, 36 seconds:

36 seconds = 36 tics

27 minutes = 27(60) tics + 36 seconds tics = 1656 total tics
Because the minute hand has 3600 tics for a full revolution, 360 / 3600 = 0.1 degrees per tic
Therefore, 1656 tics * 0.1 = 165.6 degrees

5 hours = 5(3600) = 18000 hour tics          (1 hour equals 3600 tics)
18000 hour tics + 1656 minute tics = 19656 total tics
Because the hour hand has 43200 tics for a full revolution, 360 / 43200 = 0.00833333 -- and the decimal precision matters!
So, 19656(.008333333) = 163.7999934 degrees

The final angle is 165.6 - 163.7999934 = 1.8 since the hour hand is close to the minute hand in this scenario.