Feature: SauceDemo

Login to the saucedemo page and perform actions

@tag1
Scenario: Saucedemo Feature
	Given I am login to Saucedemo page
	And  I Enter the Demo credentials from login page
	And I Select any item 
	And Note the price from the inventroy page and add it to cart.
    When Navigate to cart page 
	Then verify same price as above noted displayed.
	When Click on checkout
	And Enter the sample details
	And Click continue
	Then Verify the Item and Price on chekout page.
	And Click finish.
