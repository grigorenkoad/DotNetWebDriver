Feature: SpecFlowTests
	In order to check work of wordpress self-created page
	As a moderator
	I want to add and delete posts and check that it happens

@login
Scenario: Incorrect login
	Given I entered wordpress main page
	When I try to login with wrong account
	Then I see error message

@login
Scenario: Register a user
	Given I entered wordpress main page
	When I register new user
	Then I can assign new password

@login
Scenario: Correct login
	Given I registered a user
	When I try to login with right account
	Then I see dashboard

@post
Scenario: Add a post
	Given I am logged as moderator
	When I add a post
	Then Post is displayed on main page

@comment
Scenario: Add a comment
	Given I am logged as moderator
	And There is some post
	When I add a comment to the post
	Then Comment is displayed under the post

@comment
Scenario: Delete a comment
	Given I am logged as moderator
	And There is some post with comment
	When I delete the comment
	Then Comment is not displayed under the post

@post
Scenario: Delete a post
	Given I am logged as moderator
	And There is some post
	When I delete the post
	Then Post is not displayed on main page