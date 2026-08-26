# .NET Technical Assessment

Technical Assessment for Associate Software Engineer (.NET)

## How to Run

Navigate to the project directory:

Restore dependencies:

``` dotnet restore ```

Run the API:

``` dotnet run --project .\src\AwareAssessment.Api\ ```

In this Assessment I Use Postman to test the APIs.


## Authorization
make sure you POST `/api/auth/login` to get the token and use it in the header for the GET request.
and in Postman, select Authorization tab, select Bearer Token and paste the token in the Token field.

## For Test Any Task

I will use Postman to test the APIs.

Example Task 1 GET `/api/products`

## Unit Tests

Unit tests are implemented for the duplicate-value logic in Task 2 (Sort).

The tests verify the expected results for duplicate values and sorting.

Test framework:	xUnit

Run tests with:

``` dotnet test ```

Thank you for sending me your assessment and taking the time to review it. ^O^