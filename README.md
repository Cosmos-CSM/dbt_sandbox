# *Sandbox Database Template*

This repository provides database template projects, this are pre-configured databases for ORM support on different
frameworks, is intended to be connected and work immediate OOB, but they provide a customization layer to extend base behavior.

> For version details check [CHANGELOG](./sandbox_database_template/CHANGELOG.md)

## **Database Structure**

Here you will be guide along the current database structure, for more structure details per version, please check *CHANGELOG.md*.

### Entities

- Entity 1

### Relations

- (1:1 / 1:M / M:M) Entity 1 (Dependant) -> Entity 2 (Dependency).

> Dependant: Is the entity that has as a property the reeference to the [Dependency].
> Dependency: Is the entity referenced from a [Dependant].

### <Extras (StoredProcedures/CustomViews/CustomReports. Etc)>

## **Installation & Usage**

Here you will be able to see how use this database template in your business project.

> dotnet nuget add source --name "github" --username {*GITHUB.USR*} --password {*GITHUB.PAT*} "<https://nuget.pkg.github.com/Cosmos-CSM/index.json>"

- GITHUB.USR: It's your github user account.

- GITHUB.PAT: It's a generated personal access token, go to *Settings* > *Developer Settings* > *Personal access tokens*, create a **Classic** type access token and provide at minimum **Read:Packages** permission.

> dotnet add package **Sandbox.Database.Template** --source github
