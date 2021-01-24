Feature: Fluent tests

  Scenario: full fluent div
    Given A new application
    And I create a full Fluent div
    Then Check if fluent div has attribute keyA with value valueA
    Then Check if fluent div attribute keyB removed    