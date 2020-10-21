# PasswordValidation

## Purpose
C# sample code to demonstrate a more elegant way to perform password validation by using OOP concept and C# features (generics, linq and regular expression). 

## Problem:

Validates a password to conform to the following rules:

- Length between 6 and 24 characters.
- At least one uppercase letter (A-Z).
- At least one lowercase letter (a-z).
- At least one digit (0-9).
- Maximum of 2 repeated characters.
  - "aa" is OK 
  - "aaa" is NOT OK 
- Concecutive repeated substring is NOT allowed.
  - "Abc&Abc&Abc&" is NOT OK
- Supported special characters:
  * ! @ # $ % ^ & * ( ) + = _ - { } [ ] : ; " ' ? < > , .

## Notes:

Traditionally, the problem is simple enough to be solved by using if..else..
branching. However, there are a few drawbacks:
  - code change required when rule changed or new rule added
  - hard to test
  - hard to read or understand

Considering these limitations, using OOP concept and applying some SOLID principle 
can solve this problem in a better way as in extensibility, reusability,
testability and maintainability:
  - IValidationRule interface is an abstraction, concrete rules can be simply
    implemented as required
  - Client has freedom to choose any combination of rules according to their
    needs
  - Each rule can be tested individually to reduce the bug
  - Code is clean and easy to understand
