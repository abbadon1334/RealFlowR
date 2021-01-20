Feature: Element And Message Tests
  
  Scenario: Test Creation
    Given A new application starts
    When I get a message
    Then Check the message method : OnInit
    
  Scenario: Test SetAttribute 
    Given A new application starts
    When I get a message
    Given I add a div component    
    When I get a message
    Then Check attribute id is not null
    Then Check the message method : CreateElement
    Given I SetAttribute name with test
    Then Check attribute name has value test
    When I get a message
    Then Check the message method : SetAttribute
    Given I remove the element
    When I get a message
    Then Check the message method : RemoveElement

  Scenario: Test Remove Element
    Given A new application starts
    When I get a message
    Given I add a div component
    When I get a message
    Given I remove the element
    When I get a message
    Then Check the message method : RemoveElement