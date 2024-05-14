# Capital Placement Assessment

## Updates

The step by step updates I made are enumerated below:

- The configuration of the database was the first step, and I abstracted all the logic from the controllers in order to keep them lean and simple, including the validation of the request body. Fluent validation was used to sanitize and check the candidates' and questions' data.

- `Enum` was used for the question and gender types. This allowed a seamless integration with the FluentValidation validators which were registered in the `Services` and injected via an auto validation.

- `AutoMapper` package allowed easy conversion between DTOs and entity classes.

- The `IOptions<>` interface was handy in the access of enviroment variables. This was pivotal as the access to database `Conatiners` were dynamic for services.

- The API endpoint for querying questions by type takes a query parameter, `questionType`, which can be any of the valid question types. If ths parameter is not empty, quaetions that have the same type are returned as a response.

- I added an endpoint to get all candidates. The query to the database orders the candidates by `FirstName`, then by `LastName`. For this to work, I needed to create `Composite Indices` on those properties in the database.

See [Managing Indexing Policies](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/how-to-manage-indexing-policy?source=recommendations&tabs=dotnetv3%2Cpythonv3) and [Azure cosmos NoSQL orderby](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/query/order-by)

This is the Indexing policy JSON:

```json
{
    "indexingMode": "consistent",
    "automatic": true,
    "includedPaths": [
        {
            "path": "/*"
        }
    ],
    "excludedPaths": [
        {
            "path": "/\"_etag\"/?"
        }
    ],
    "compositeIndexes":[  
        [  
            {  
                "path":"/firstName",
                "order":"ascending"
            },
            {  
                "path":"/lastName",
                "order":"ascending"
            }
        ]
    ]
}
```

- I used the Azure cosmos db NoSQL Emulator to test the API endpoints.
