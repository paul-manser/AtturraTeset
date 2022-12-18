# Code Test


## WHY

This was created to demonstrate my style and ability of coding and awareness of different aspects.

The solution breaks uses a repository pattern (Repositories) (partially implemented with dummy data)
to get obects that represent the deductions (just created inline). 
The UI (UserInterface) is again seperated from the business logic (Engine).

The application was mainly developed through the unit tests whih you can run to verify the results as 
well as running the main applicaiton.

Interfaces were used extensively as apposed to inheritance as I believe it gives better ability to extend
the application in the future.

Unhandled exceptions are cought and logged (to debug console).

Not much time has been given to user validation due to time issues with the family over the weekend 
(the weekend before Christmas). This could easilty be improved by putting in a small loop instead of
throwing the exception with a message.

Even through there is not IOC container, all the main elements are created with IOC in mind passing
in all the dependencies this inversion of control principle combined with the extensive use of interfaces
allows for obeject to be swapped out as needed for extensibility.


## POSSIBLE CHANGES TO DEDUCTABLES

If the tax tables or other deductables were changed in the future the "imagine" database would be
updated and appropiate IDeduction would be returned. All of the types of deduction (Tax, Super, Other) 
are of this common base interface with the calucate method that, although hard coded because of time, could be
based on the query data returned based on the active tax table, super contribution and other deductables.

The PayDetails object is create with the result data, this could be written to a database to preserve the
state and calculations that were made for this report if it needs to be audited in the future. As when the
rules for the deductables are changed existing reports may need to be viewed to know the historic calulations
made. This could be extended to to have a forign key relationship to the actual tax tables etc used for
the calulations.


## Improvements that could be made but are not implemented due to time constraints

- there could be a AsyncRepository pattern. A basis for this exists as IAsyncRepository
- more comments could be added to the code but I feel most of this is self expanitory
- more unit tests (I wrote them as I used them, not particularly aiming for high coverage)
- pulling the seperate areas into there own projects (Engine, UI, Repositories).
- I hard wired the calculations for the different deductions which should be done with data from a db
