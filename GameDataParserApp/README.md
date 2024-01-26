# Game data parser

## Overview
This application reads and deserializes video game data  from a JSON file. It is robust and should not crash under any circumstances. Any unhandled exceptions are written to the log file.

## Sample input JSON:
    [
      {
        "Title": "Stardew Valley",
        "ReleaseYear": 2016,
        "Rating": 4.9
      },
      {
        "Title": "Frostpunk",
        "ReleaseYear": 2017,
        "Rating": 4.7
      },
      {
        "Title": "Oxygen Not Included",
        "ReleaseYear": 2017,
        "Rating": 4.8
      },
      {
        "Title": "Red Dead Redemtpion II",
        "ReleaseYear": 2018,
        "Rating": 4.8
      },
      {
        "Title": "Portal 2",
        "ReleaseYear": 2011,
        "Rating": 4.8
      }
    ]

##  Main application workflow
- When the application starts, it shall print: </br> ***Enter the name of the file you want to read:***
- The user must enter the name of an existing file. The app should keep asking the user to enter the file until the valid name is entered. See Entering the file name by the user for more details.
- Next, the app tries to read the video game data from the given file. See Reading the data from the JSON file.
- If the file contains valid JSON
  - Sample file: https://drive.google.com/file/d/1xfSqAdaNglliZqgi-q1Tune8G500mVCo/view?usp=sharing
  - Video games read from the file are printed to the screen. See Printing video games.
- If the file does not contain valid JSON
  - Sample file: https://drive.google.com/file/d/1UKdgCMSTcY8oduWGaDCxrZQ7AjmzNUgP/view?usp=sharing
  - “JSON in the FILE_NAME was not in a valid format. JSON body:” is printed to the console in red, followed by the contents of the JSON file.
  - “Sorry! The application has experienced an unexpected error and will have to be closed.” is printed.
  - A new entry is added to the log file, containing the date and time of the exception, the exception message, and the stack trace. See Logging exceptions in a file for more information.
- Finally, the app prints “Press any key to close.” and after that, the window closes.

## Reading the data from the JSON file
We, as the developers of this app, do not create the JSON files ourselves. We can imagine we read them from the web, or from some database. We must create our code in such a way, that it can handle the given files.

An example of a valid file can be found here: https://drive.google.com/file/d/1xfSqAdaNglliZqgi-q1Tune8G500mVCo/view?usp=sharing

<img width="470" alt="image" src="https://github.com/rahul-jha-official/Projects/assets/138975150/fdfce2f9-d665-43c8-bf21-e1c1d9842842">

## Printing video games
<img width="470" alt="image" src="https://github.com/rahul-jha-official/Projects/assets/138975150/d1313475-dd03-43dc-9d45-04a145de38d0">

## Logging exceptions in a file
Once the application experiences an unhandled exception for the first time, it should create a log.txt file that will store information about all unhandled exceptions.

This should specifically include an exception thrown when we try to deserialize a file containing invalid JSON, but also all other exceptions that are not handled otherwise.

New entries should never override the old ones - they should be appended to the file. 

Each entry should contain:
- Date and time when the exception happened
- The exception message
- The stack trace

The exact format of the log file is at the developer’s discretion.

An example of the log file contents could be : </br>

[12/1/2022 8:00:13 AM], Exception message:EXCEPTION_MESSAGE_1, Stack trace:    STACK_TRACE_1

[12/1/2022 8:00:15 AM], Exception message:EXCEPTION_MESSAGE_2, Stack trace:    STACK_TRACE_2

You can also find an example of a logged file under this link: https://drive.google.com/file/d/16hpQik8gATemu13iVIypqaMn1h_2BCWK/view?usp=sharing
