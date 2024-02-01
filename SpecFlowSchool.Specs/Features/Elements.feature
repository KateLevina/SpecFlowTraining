Feature: Elements category

Background:
	Given DemoQA Home page is opened
	And Selected category is Elements

#@elements_category
#Scenario Outline: TextBox values are processed correctly
#	Given Selected section is Text Box
#	When user enters values for the fields
#	And Press Submit button
#	Then Values displayed in table below are the same as values which were entered to the fields
#Examples:
#	| fullname   | email           | current address | permanent address     |
#	| John       | john@sdf.com    | first street    | another street 10     |
#	| John Smith | john.sm@sdf.com | location        | another street 10, 35 |
#
#@elements_category
#Scenario: Checkbox section
#	Given CheckBox section is selected
#	When user expands 'Home' folder
#	And selects Desctop folder (not expanding it)
#	And selects Angular and Veu from WorkSpace order
#	And expands Office folder
#	And selects all items in it one by one
#	And expands Downloads folder
#	And selects all items clicking on Downloads folder
#	Then check that selected value is "You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile"
#
#@elements_category
#Scenario: Web Tables - sorting by Salary column
#	Given Web Tables section is selected
#	When user clicks on Salary column header
#	Then all items in table are placed according to salary value ascending.
#
#@elements_category
#Scenario: Web Tables - delete row
#	Given Web Tables section is selected
#	And table has 3 rows
#	And second row name value is Alden
#	When user seletes the second row with Alden name
#	Then only 2 rows are left in table
#	And Compliance value is not present in Department column
#
@elements_category
Scenario Outline: Click Button 
	Given Selected section is Buttons
	When user interacts with <buttonName> button appropriate way
	Then <message> message is present in the form below.
Examples:
	| buttonName      | message                       |
	| Double Click Me | You have done a double click  |
	| Right Click Me  | You have done a right click   |
	| Click Me        | You have done a dynamic click |