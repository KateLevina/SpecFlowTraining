Feature: Elements category

Background:
	Given DemoQA Home page is opened
	And Selected category is Elements

@elements_category
Scenario: TextBox values processed correctly
	Given Selected section is Text Box
	When Valid values are entered in Text Box section fields
		| fullname   | email           | current address | permanent address     |
		| John Smith | john.sm@sdf.com | location        | another street 10, 35 |
	And Submit button pressed
	Then Values displayed in table below are the same as values which were entered to the fields

@elements_category
Scenario Outline: Click Button
	Given Selected section is Buttons
	When user presses <buttonName> button appropriate way
	Then <message> message is present in the form below
Examples:
	| buttonName      | message                       |
	| Double Click Me | You have done a double click  |
	| Right Click Me  | You have done a right click   |
	| Click Me        | You have done a dynamic click |