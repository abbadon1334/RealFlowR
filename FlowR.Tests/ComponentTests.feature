Feature: Component tests

  Scenario: Test check css
    Given A new application
    And I add a div component
    And I SetAttribute class with btn
    Then Check attribute class has value btn
    
    And I Add class success
    Then Check attribute class has value btn success

    And I Remove class btn
    Then Check attribute class has value success
