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

This branch is demonstrating that using if..else.. conditional
branching to solve the problem. However, there are a few drawbacks:
  - code change required when rule changed or new rule added
  - hard to test
  - hard to read or understand

## Run tests:

Enter following steps in Command Line terminal to run test:
  cd PasswordService.Tests
  dotnet test

  ...
  Test Run Successful.
  Total tests: 14
       Passed: 14
  Total time: 9.3109 Seconds
