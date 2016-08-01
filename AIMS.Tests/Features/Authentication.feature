Feature: Authentication

Background: 
	Given I open login page
	


Scenario: Check_successfull_login_and_logout_from_portal
	Given I login to portal
	When I will logout from portal
	Then I will get login page

Scenario: Check_login_to_portal_without_password
	Given I have enter right username
	And I have not entered user password(empty step)
	When I will try to login to portal(empty step)
	Then I will get tooltip with warning if I click login button

Scenario: Check_login_to_portal_without_email
	Given I have enter right user password
	And I have not entered username(empty step)
	When I will try to login to portal(empty step)
	Then I will get tooltip with warning if I click login button

Scenario: Check_login_to_portal_using_wrong_username
	Given I have entered wrong username
	And I have enter right user password
	When I try to login to portal
	Then I will get login page error message "Incorrect email or password"

Scenario: Check_login_to_portal_using_wrong_password
	Given I have enter right username
	And I have enter wrong password
	When I try to login to portal
	Then I will get login page error message "Incorrect email or password"