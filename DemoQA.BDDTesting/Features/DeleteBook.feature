@DeleteBook
Feature: Delete a book
    As a user
    I want to delete a book from my collection

    Background: Book exist
    Given there is a book named "Git Pocket Guide" in "account_01" collection

    @HappyCase
    Scenario: Delete book successfully
        Given I go to Login Page
        And I login successfully with the account "account_01"
        When I enter book name "Git Pocket Guide" into search box
        And I delete the book "Git Pocket Guide"
        Then the book "Git Pocket Guide" should disappear from my collection