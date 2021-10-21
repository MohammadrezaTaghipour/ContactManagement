Feature: Defining Contact
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: new contact gets defined properly
	When I define a new contact with following info
		| Name          | Email                             | PhoneNumber   | Organization | GithubAccountName     |
		| Mohammad Reza | moahamadrezataghipour73@gmail.com | +989918859951 |              | MohammadrezaTaghipour |
	Then I will see that the contact is defined properly within the list