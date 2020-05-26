Feature: KiwiRail

Background:
	Given I navigate to the Kiwi Rail Website
	Then I verify that I am on Kiwi Rail Website Main Page

Scenario: Verify different header links on Kiwi Rail Main Page
	Then I verify the main header navigation links are:
		| links            |
		| What we do       |
		| Our story        |
		| How can we help? |
		| About us         |

Scenario Outline: Verify the navigation links menu item route to correct page
	When I hover over the Primary Navigation menu : <navMenu>
	And I click the menu item : <menuItem>
	Then I verify that I am on the page : <pageHeader>

	Examples:
		| navMenu    | menuItem               | pageHeader             |
		| What we do | Freight                | Freight                |
		| What we do | Tourism                | Tourism                |
		| What we do | Interislander          | Interislander          |
		| What we do | Network Transformation | Network Transformation |
		| What we do | Property               | Property               |
		| What we do | Zero Harm              | Zero Harm              |
		| What we do | Our assets             | Our assets             |