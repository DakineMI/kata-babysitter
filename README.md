# Babysitter Kata

## Background
This kata simulates a babysitter working and getting paid for one night.  The rules are pretty straight forward.

The babysitter:
- starts no earlier than 5:00PM
- leaves no later than 4:00AM
- gets paid $12/hour from start-time to bedtime
- gets paid $8/hour from bedtime to midnight
- gets paid $16/hour from midnight to end of job
- gets paid for full hours (no fractional hours)


## Feature
*As a babysitter<br>
In order to get paid for 1 night of work<br>
I want to calculate my nightly charge<br>*


## How to execute the tests from the command line
1. Build the solution in debug mode, ensuring to restore the NuGet packages.
2. Open a command prompt or PowerShell command window. In the window, navigate to the root folder of the solution.
3. Execute the following command:
	packages\xunit.runner.console.2.3.1\tools\net452\xunit.console BabysitterCalculator\bin\Debug\BabysitterCalculator.dll
4. The tests should execute and test summary should be displayed in the window.

