# GraphQL API Example

This project is a simple **GraphQL API** built with **HotChocolate** for managing users. The API allows you to perform CRUD operations, including querying users and adding new ones.

## Table of Contents
1. [Installation](#installation)
2. [Configuration](#configuration)
3. [GraphQL Operations](#graphql-operations)
   - [Queries](#queries)
   - [Mutations](#mutations)

## Installation

### Prerequisites
- **.NET SDK** version 8.0 or higher
- **Visual Studio** or any IDE that supports .NET development

### Clone the Repository

```bash
git clone https://github.com/Argan12/graphql-api-example.git
cd graphql-api-example
```

### Restore dependencies and build
```bash
dotnet restore
dotnet build
```

### Run the application
```bash
dotnet run
```

Your API should be up and running at https://localhost:7200/graphql

### Configuration
This API uses HotChocolate for GraphQL implementation. It is configured to support querying and mutating User entities. You can access the GraphQL playground at http://localhost:7200/graphql to try the operations.

## GraphQL Operations Examples
### Queries
#### Get user by mail
To fetch a user by their email address, use the following query:

```
query {
  userByMail(input: { mail: "johndoe@example.com" }) {
    id,
    pseudo,
    mail,
    registrationDate
  }
}
```

Response can be filtered: 
```
query {
  userByMail(input: { mail: "johndoe@example.com" }) {
    pseudo
  }
}
```

### Mutations
#### Create a New User

To create a new user, use the following mutation:

```
mutation {
  createUser(input: {
    pseudo: "JohnDoe",
    mail: "johndoe@example.com"
  }) {
    id
    pseudo
    mail
    registrationDate
  }
}
```
