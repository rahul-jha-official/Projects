# Online Scheduler
An online scheduler website for my car service agency.

## Problem Statement
My agency has many service operators who must take in appointments for customers for a limited time. A Service operator can take 1-hour appointments for all 24 hours, and they are available 24 x 7 x 365 days (sorry no vacation for them). If a Service operator is booked for a specific timeslot, he obviously cannot take any more customer appointments.

## Functionality
I want to be able to do the following: </br>
Ability to 'book an appointment slot by specific Operator or any Ability to 'reschedule' or 'cancel' appointment Ability to show all booked appointments of an operator.

Ability to show all booked appointments of an
operator. This should display all individual appointments ie. 1-2, 2-3, 3-4. Ability to show open slots of appointments for an operator. This should merge all consecutive open slots and show as 4-14 instead of 4-5, 5-6 .. 13-14

## Notes/Assumptions
- Number of service operators can be hardcoded to 3- ServiceOperator0 ServiceOperator1, ServiceOperator2
- Please give an identifier to Appointment Id. This is crucial part of system which allows auditing
- Don't worry about customers aspect.
- Assume that you just have 1 customer who is booking multiple appointments at the same time or at different times of day/week
- I am not concerned with dates as well.
- Solve the problem for a single day (but ensure your solution can be expanded to work with say weekly schedule or yearly calendar)
- Don't worry about AM/PM. Use 24-hour format as it will greatly simplify your solution too.

## Work expected
- Any user interface with persistent storage.
- Submissions
  - Console app with file as data store
  - Rest API with backend SQL as data store
  - Website with backend SQL as data store
 
Feel free to choose any of the above submission types based on your experience which fit the 4-hour schedule. Don't spend more than 4 hours on the problem. This is crucial.

## Focus on
- Code module with relevant data structure, not on solving all the scenarios of the problem.I want to understand your strengths on how you tackle a problem statement and how do you make program choices.
- Feel free to use any open-source libraries or use Stack overflow or any other code examples online. But I would like to see comments with original source links.
- Guide on how to run the program. Assume that I don't have all the software installed.
- When in doubt, make reasonable assumption and move on. You won't have ability to clarify the problem statement even though it is ambiguous.

- ## Don't focus on
- Beautiful code with perfect naming conventions.
- Agility matters here more than how it looks. Although, that doesn't mean the code should look shabby :)
- Hosting the code, programming language Adding lot of comments. Add relevant comments if you think code is not self-explanatory.
  
