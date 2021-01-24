Feature: Component tests

  Scenario: Test check css
    Given A new application
    And I add a div component
    And I SetAttribute class with btn
    Then Check attribute class has value btn

    Given I SetAttribute class with btn success
    Then Check attribute class has value btn success

    Given I SetAttribute class with btn btn success success
    Then Check attribute class has value btn success

    Given I add class success
    Then Check attribute class has value btn success

    Given I remove class btn
    Then Check attribute class has value success

  Scenario: Test add same class twice
    Given A new application
    And I add a div component
    And I add class first
    Then Check attribute class has value first

    Given I add class second
    Then Check attribute class has value first second

    Given I add class second
    Then Check attribute class has value first second

    Given I remove class second
    Then Check attribute class has value first

  Scenario: Test mix SetAttribute add same class twice
    Given A new application
    And I add a div component
    And I SetAttribute class with btn first first
    And I add class first
    Then Check attribute class has value btn first
