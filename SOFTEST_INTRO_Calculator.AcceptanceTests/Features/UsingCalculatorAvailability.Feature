@Availability
Feature: UsingCalculatorAvailability
	In order to calculate MTBF and Availability
	As someone who struggles with maths
	I want to be able to use my calculator to do this

	Scenario Outline: Calculating MTBF
		Given I have a calculator
		When I have entered <operatingTime> and <FailureCount> into the calculator and press MTBF
		Then the result should be <MTBF>

		Examples:
			| operatingTime | FailureCount | MTBF |
			| 200 | 10 | 20 |
			| 100 | 1 | 100|
	
	Scenario Outline: Rejecting MTBF with invalid input
		Given I have a calculator
		When I have entered <operatingTime> and <FailureCount> into the calculator and press MTBF
		Then MTBF should be rejected

		Examples:
			| operatingTime | FailureCount |
			| 0 | 10 |
			| 100 | 0 |
			| -100 | 10 |
			| 100 | -10 |
		
	Scenario Outline: Calculating Availability
		Given I have a calculator
		When I have entered <mtbf> and <mttr> into the calculator and press Availability
		Then the result should be <availability>

		Examples:
			| mtbf | mttr | availability |
			| 200 | 10 | 0.9523809523809523 |
			| 100 | 0 | 1 |
			| 0 | 100 | 0 |
	
	Scenario Outline: Rejecting Availability with invalid input
		Given I have a calculator
		When I have entered <mtbf> and <mttr> into the calculator and press Availability
		Then availability should be rejected

		Examples:
			| mtbf | mttr |
			| -100 | 10 |
			| 10 | -10 |
			| 0 | 0 |
	
	Scenario: Calculating Availability from named reliability values
		Given I have a calculator
		And the reliability values are
			| MTBF | MTTR |
			| 90 | 10 |
		When I calculate Availability from these values
		Then the result should be 0.9