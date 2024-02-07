Feature: Windows category

Background:
	Given DemoQA Home page is opened
	And Selected category is Alerts, Frame & Windows

@windows_category
Scenario: New Tab Or Window
	Given Selected section is Browser Windows
	When <buttonName> button is pressed and switched to new handle
	Then Sample text is present on new page
Examples:
	| buttonName |
	| New Window |
	| New Tab    |
