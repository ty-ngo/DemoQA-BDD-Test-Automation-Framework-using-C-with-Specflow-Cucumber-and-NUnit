@SearchBook
Feature: Search book
    As a user I want to search book on the Book Store page

    @HappyCase
    Scenario Outline: Search book with multiple results successfully
        Given I go to Book Store Page
        When I input the key word "<value>" into search box
        Then all books matching with the key word "<value>" is displayed

        Examples:
            | value  |
            | Design |
            | design |