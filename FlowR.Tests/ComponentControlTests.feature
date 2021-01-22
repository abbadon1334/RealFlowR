Feature: Controls tests

  Scenario: Test add a control
    Given A new application
    And Add a form
    And Add control to form with name fldTest
    Then Check if input fldTest is binded to form
    Then Check if input fldTest has attribute type with value text
