Feature: Dashboard

Background: 
	Given I open login page
	And I login to portal
	And I select "Test (test)" environment using it name

Scenario Outline: Check_blocks_on_dashboard_page
	Then <blockname> block will be present on dashboard page

	Examples: 
	| blockname          |
	| Warnings           |
	| Errors             |
	| Avg. message delay |
	| Message count      |


Scenario: Check_warnings_block_on_dashboard_page
	Then "Warnings" block will be present on dashboard page

Scenario: Check_that_date_intervals_in_warnings_block_displays_correctly_on_dashboard_page
	Then Date intervals in "Warnings" block will be displayed correctly
	And I can select default date boundary values from dropdown menu
	| Date boundary values              |
	| Today vs Yesterday                |
	| Past 7 days vs Preceding 7 days   |
	| Past 31 days vs Preceding 31 days |
	| Current week vs Previous week     |
	| Current month vs Previous month   |

Scenario: Check_Errors_block_on_dashboard_page
	Then "Errors" block will be present on dashboard page

Scenario: Check_that_date_intervals_in_errors_block_displays_correctly_on_dashboard_page
	Then Date intervals in "Errors" block will be displayed correctly
	And I can select default date boundary values from dropdown menu
	| Date boundary values              |
	| Today vs Yesterday                |
	| Past 7 days vs Preceding 7 days   |
	| Past 31 days vs Preceding 31 days |
	| Current week vs Previous week     |
	| Current month vs Previous month   |
	

Scenario: Check_Avg.messageDelay_block_on_dashboard_page
	Then "Avg. message delay" block will be present on dashboard page

Scenario: Check_that_date_intervals_in_avg_message_delay_block_displays_correctly_on_dashboard_page
	Then Date intervals in "Avg. message delay" block will be displayed correctly
	And I can select default date boundary values from dropdown menu
	| Date boundary values              |
	| Today vs Yesterday                |
	| Past 7 days vs Preceding 7 days   |
	| Past 31 days vs Preceding 31 days |
	| Current week vs Previous week     |
	| Current month vs Previous month   |

Scenario: Check_MessageCount_block_on_dashboard_page
	Then "Message count" block will be present on dashboard page

Scenario: Check_that_date_intervals_in_message_count_block_displays_correctly_on_dashboard_page
	Then Date intervals in "Message count" block will be displayed correctly
	And I can select default date boundary values from dropdown menu
	| Date boundary values              |
	| Today vs Yesterday                |
	| Past 7 days vs Preceding 7 days   |
	| Past 31 days vs Preceding 31 days |
	| Current week vs Previous week     |
	| Current month vs Previous month   |

Scenario: Check_dailyAPDEXSCORE_block_on_dashboard_page
	Then "Daily APDEX SCORE" block will have proper title on dashboard page

Scenario: Check_ActivityAndChanges_block_on_dashboard_page
	Then "Activity & changes" block will have proper title on dashboard page
	And Current date in "Activity & changes" block will be displayed correctly
	And I can select default date boundary values from dropdown menu
	| Date boundary values |
	| Today                |
	| Past 7 days          |
	| Past 31 days         |
	| Current week         |
	| Current month        |	

Scenario: Check_TopGroupsByMessageCountChange_block_on_dashboard_page
	Then "Top groups by Message count change" block will be present on dashboard page

Scenario: Check_that_date_intervals_in_TopGroupsMyMessageVolumeChange_block_displays_correctly_on_dashboard_page
	Then Date intervals in "Top groups by Message count change" block will be displayed correctly
	And I can select default date boundary values from dropdown menu
	| Date boundary values              |
	| Today vs Yesterday                |
	| Past 7 days vs Preceding 7 days   |
	| Past 31 days vs Preceding 31 days |
	| Current week vs Previous week     |
	| Current month vs Previous month   |

Scenario: Check_TopGroupsByMessageDelay_block_on_dashboard_page
	

Scenario: Check_PerformanceParametersOfBizTalk_block_on_dashboard_page
	Then "Performance parameters of BizTalk" block will have proper title on dashboard page