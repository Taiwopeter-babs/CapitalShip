# Capital Placement Assessment

## Updates

The step by step updates I made are enumerated below:

- The configuration of the database was the first step, and I abstracted all the logic from the controllers in order to keep them pure and simple, including the validation of the request body. Fluent validation was used to sanitize and check the candidates' and questions' data.

- `Enum` was used for the question and gender types. This allowed a seamless integration with the FluentValidation validators which were registered in the `Services` and injected via an auto validation.

- `AutoMapper` package allowed easy conversion between DTOs and entity classes.

- The `IOptions<>` interface was handy in the access of enviroment variables. This was pivotal as  access to `Conatiners` were dynamic for services.

I used the Azure cosmos db NoSQL Emulator to test the API endpoints.
