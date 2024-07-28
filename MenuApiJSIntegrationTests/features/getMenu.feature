Feature: What's the menu?
    Everybody wants to know the restaurant's menu
    
    Scenario: Get the Menu
        Given the playwright menu is available

    Scenario: Menu makes customer happy
        Given the playwright menu is available
        When Henry requests to see the menu
        And the menu contains his favorite dish, 'Spaghetti'
        Then he feels 'happy', and is satisfied