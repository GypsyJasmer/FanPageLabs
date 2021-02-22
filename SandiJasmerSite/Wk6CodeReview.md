# Code Review Form

|                                                      | See ZAP notes below                        |
| ---------------------------------------------------- | ------------------------------------------ |
| Course  number, lab number and lab group             |                                            |
| Developer                                            | Sandi Jasmer                               |
| URL  for the project repository and branch on GitHub | https://github.com/GypsyJasmer/FanPageLabs |
| URL  on a server (if it has been published)          | jasmers-001-site1.ctempurl.com             |
| Reviewer  and Date                                   |                                            |

###  Instructions

The reviewer will complete this form for the beta version of a lab assignment done by one of their lab partners. After filling out the “Beta” column and adding comments, the reviewer will submit this document to the Code Review assignment on the LMS.

The developer will revise the beta version of their lab work and fill out the “Production” column to reflect any changes they have made. The developer will submit this completed form along with the production version of their lab assignment.

### Review

Add explanatory comments in the row following any "no" answers.

| **Criteria**                                                 | **Beta**                   | **Release** |
| ------------------------------------------------------------ | -------------------------- | ----------- |
| Does it compile and run without errors?                      | Yes                        |             |
| Do all the pages load correctly?                             | Yes                        |             |
| Does the style conform to MVC conventions and our class standards? | Yes                        |             |
| Do all the links, buttons or other UI elements work correctly? | Yes                        |             |
| Do the design and implementation conform to OOP best practices? | Yes                        |             |
| Does the style conform to C# coding conventions?             | Yes                        |             |
| Does the solution meet all the requirements?                 | Yes                        |             |
| Summary Comments: See below notes concerning Zap Reporting.  |                            |             |
|                                                              |                            |             |
| Zap Reporting:                                               |                            |             |
| A list of the high, medium and low priority issues that came up in the initial passive and active scans of your app. | See ZapReport Doc          |             |
| -Working on these three risks:  Cross Site Scripting (Reflected), Format String Error, X-Frame-Options Header Not Set |                            |             |
| The issues you chose to mitigate and the classes and methods that you changed to implement the mitigation. |                            |             |
| -Working on fixing login post methods, ran into cross site scripting, both in the account controller. https://portswigger.net/web-security/cross-site-scripting/cheat-sheet                                                                                                                                            -Format String Error fix in home controller and stories view.                                                                           -X-Frame-Options Header Not Set shows up 17 times in my code and is based around my get methods and only 3 post methods. |                            |             |
|                                                              |                            |             |
| A list of the issues that come up in passive and active scans after making the code changes. | Haven't ran after fix yet. |             |
|                                                              |                            |             |

 

 

## Appendix

### Aspects of coding style to check

- Is proper indentation used?
- Are the HTML elements and variables named descriptively?
- Have any unnecessary lines of code or files been removed?
- Are there explanatory comments in the code?
- Do variable names use camelCase? 
- Are properties, methods and classes named using PascalCase (aka TitleCase)?
- Are constant names written using ALL_CAPS?



### Best practices in Object Oriented Programming

- Is the code DRY (no duplicated blocks of code)?
- Are named constants used instead of repeated literal constants?
- Is code that does computation or logical operations separated into its own class instead of being added to the code-behind?
- Are all instance variables private?
- Are local variables used instead of instance variables wherever possible?
- Does each method do just one thing (no “Swiss Armey” methods)?
- Are classes “loosely coupled” and “highly coherent”?

 

------

Written by Brian Bird, Lane Community College, winter 2017, updated winter 2020

------
