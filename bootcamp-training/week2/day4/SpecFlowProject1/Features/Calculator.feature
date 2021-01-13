Feature: Calculator
    In order to avoid silly mistakes
    As a math idiot
    I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
    Given the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120

@mytag
Scenario: Divide two numbers
    Given the numerator is 14
    And the denominator is 7
    When the numbers are divided
    Then the result should be 2
    When the denominator is 0
    Then divide by zero exception
