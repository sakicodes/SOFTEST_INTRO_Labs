@BasicMusa
Feature: UsingCalculatorBasicReliability
	In order to calculate the Basic Musa model's failures and intensities
	As a Software Quality Metric enthusiast
	I want to use my calculator to do this

	Scenario Outline: Calculating Current Failure Intensity
		Given I have a calculator
		When I have entered <initialFailureIntensity>, <expectedTotalFailures> and <executionTime> into the Calculator and press Current Failure Intensity
		Then the result should be <currentFailureIntensity>

		Examples:
			| initialFailureIntensity | expectedTotalFailures | executionTime | currentFailureIntensity |
			| 10 | 100 | 10 | 3.678794412 |
			| 10 | 100 | 0  | 10 |
	
	Scenario Outline: Calculating Expected Cumulative Number of Failures
		Given I have a calculator
		When I have entered <initialFailureIntensity>, <expectedTotalFailures> and <executionTime> into the Calculator and press Expected Cumulative Number of Failures
		Then the result should be <expectedResult>

		Examples:
			| initialFailureIntensity | expectedTotalFailures | executionTime | expectedResult |
			| 10 | 100 | 10 | 63.21205588 |
			| 10 | 100 | 0  | 0 |
	
	Scenario Outline: Rejecting Current Failure Intensity with invalid input
		Given I have a calculator
		When I have entered <initialFailureIntensity>, <expectedTotalFailures> and <executionTime> into the Calculator and press Current Failure Intensity
		Then Basic Musa calculation should be rejected

		Examples:
			| initialFailureIntensity | expectedTotalFailures | executionTime |
			| 0 | 100 | 10 |
			| -1 | 100 | 10 |
			| 10 | 0 | 10 |
			| 10 | -1 | 10 |
			| 10 | 100 | -1 |
	
	Scenario Outline: Rejecting Expected Cumulative Number of Failures with invalid input
		Given I have a calculator
		When I have entered <initialFailureIntensity>, <expectedTotalFailures> and <executionTime> into the Calculator and press Expected Cumulative Number of Failures
		Then Basic Musa calculation should be rejected

		Examples:
			| initialFailureIntensity | expectedTotalFailures | executionTime |
			| 0 | 100 | 10 |
			| -1 | 100 | 10 |
			| 10 | 0 | 10 |
			| 10 | -1 | 10 |
			| 10 | 100 | -1 |
