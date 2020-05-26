Feature: KiwiRail

Scenario: Verify different header links on Kiwi Rail Main Page
	Given I navigate to the Kiwi Rail Website
	Then I verify that I am on Kiwi Rail Website Main Page
	And I verify the main header navigation links are:
		| links            |
		| What we do       |
		| Our story        |
		| How can we help? |
		| About us         |

Scenario: Verify the navigation links menu items
	Given I navigate to the Kiwi Rail Website
	Then I verify that I am on Kiwi Rail Website Main Page
	When I hover over the Primary Navigation Menu Option :
	| option     |
	| What we do |
	Then I verify that the menu contains items :
	| menu options  |
	| Freight       |
	| Tourism       |
	| Interislander |
