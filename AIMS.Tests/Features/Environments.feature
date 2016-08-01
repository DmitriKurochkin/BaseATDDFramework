Feature: Environments


Scenario: Select_environments_by_names
	Given I open login page
	And I login to portal
	When I select "GUI Test" environment using it name
	Then I will get dashboard page for "GUI Test" environment

Scenario: Select_environments_by_go_to_environment_link
	Given I open login page
	And I login to portal
	When I select "GUI Test" environment using 'go to environment' link
	Then I will get dashboard page for "GUI Test" environment

Scenario: Check_that_environment_has_required_charts
	Given I open login page
	When I login to portal
	Then "Test (test)" environment will have charts
	| Chart name         |
	| Errors             |
	| Warnings           |
	| Suspended messages |
	| Stopped Nodes      |	
	And These charts will have counts