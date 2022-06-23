Feature: FirstTestCase
	Choice and comparing two cars

@car.Compare
Scenario: Choice and Compare
	When start page is open
	Then page should be opened
	When click on research page link
	Then research page is opened
	Given fill form with first trim model
	When click on search button 
	Then car page is opened
	When click on first trim comparison link
	Then Trim page is opened
	Given save trim features

	When go to main page 
	Then page should be opened
	When click on research page link
	Then research page is opened
	Given fill form with second trim model
	When click on search button 
	Then car page is opened
	When click on second trim comparison link
	Then Trim page is opened
	Given save second trim features

	When click on research page link
	Then research page is opened

	When go to Compare page
	Then compare page is opened
	Given fill fist card 
	And fill second card
	When click on Compare button
	Then car comparison page is opened
	When check features for first model
	And check features for second moodel
	Then features are correct

@jsondata
Scenario Outline: Compare price
When go to trim page 
| MakeName  | ModelName | Year | TrimName |
| <Make>       | <Model>       | <Years> | <Trim>        |
	Then Trim page is opened
	Given save trim price
	When go to main page
	Then page should be opened
	When open Advanced search page
	Then advanced search page opened
	When fill advanced search form
	Then results page have results
	When add new info
	Then results page have results
	When compare prices
	Then new car price is bigger
	Scenarios: 
	| Make          | Model   | Years | Trim         |
	| mercedes_benz | c_class | 2018  | c_300_4matic |
	| chevrolet     | camaro  | 2020  | 1ls          |

	
	
