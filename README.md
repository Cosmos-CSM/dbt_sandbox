# *Sandbox Database Template*

This repository provides database template projects, this are pre-configured databases for ORM support on different
frameworks, is intended to be connected and work immediate OOB, but they provide a customization layer to extend base behavior.

> For version details check [CHANGELOG](./sandbox_database_template/CHANGELOG.md)

## **Database Structure**

Here you will be guide along the current database structure, for more structure details per version, please check *CHANGELOG.md*.

### Entities

- *Category*: Represents a [Product] category in the system.

- *Customer*: Represents a physical consumer of [Order]s from business.

- *Order*: A business products request to attend to the [Customer].

- *OrderItem*: A product item into the [Order] request.

- *Product*: Represents an available offered business product for [Customer]s to buy.

- *Supplier*: Represents a business agent that attends [Customer]'s [Order]s.

### Relations

- (M:1) [Product](Dependant) -> [Category](Dependency).

- (M:1) [Order](Dependant) -> [Supplier](Dependency).

- (1:1) [Customer] -> [Supplier].

- (M:1) [OrderItem](Dependant) -> [Order](Dependency).

- (M:1) [OrderItem](Dependant) -> [Product](Dependency).

> Dependant: Is the entity that has as a property the reeference to the [Dependency].
> Dependency: Is the entity referenced from a [Dependant].

## **Installation & Usage**

Here you will be able to see how use this database template in your business project.

> dotnet nuget add source --name "github" --username {*GITHUB.USR*} --password {*GITHUB.PAT*} "<https://nuget.pkg.github.com/Cosmos-CSM/index.json>"

- GITHUB.USR: It's your github user account.

- GITHUB.PAT: It's a generated personal access token, go to *Settings* > *Developer Settings* > *Personal access tokens*, create a **Classic** type access token and provide at minimum **Read:Packages** permission.

> dotnet add package **Sandbox.Database.Template** --source github

We also include a testing tools and utilities for this database, you might install it using:

> dotnet add package **Sandbox.Database.Template.Testing** --source github
