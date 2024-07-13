@RegisterStudent
Feature: Register Student
    As a user I want to register new Student

    @HappyCase
    Scenario: Register Student with all fields successfully
        Given I go to DemoQA's register form page
        When I fill all fields with valid info
            | Key             | Value                               |
            | First Name      | Ty                                  |
            | Last Name       | Ngo                                 |
            | Email           | tyngo@example.com                   |
            | Gender          | Male                                |
            | Mobile          | 0123456789                          |
            | Date Of Birth   | 10 April 2024                       |
            | Subjects        | Maths, Accounting                   |
            | Hobbies         | Music, Sports                       |
            | Picture         | \TestData\Image\profile-picture.png |
            | Current Address | HCMC                                |
            | State           | NCR                                 |
            | City            | Delhi                               |
        And I click on Submit button
        Then thank you message and all student info is displayed correctly