@Factorial
Feature: UsingCalculatorFactorial
	In order to conquer factorial
	As a factorial enthusiast
	I want to understand a variety of factorial operations

	Scenario Outline: Calculate factorial
		Given I have a calculator
		When I have entered <input> and press factorial
		Then the factorial result should be <output>

		Examples:
			| input | output |
			| 5 | 120 |
			| 0 | 1 |
	
	Scenario Outline: Reject factorial with invalid input
		Given I have a calculator
		When I have entered <input> and press factorial
		Then factorial should be rejected

		Examples:
			| input |
			| 21 |
			| -1 |