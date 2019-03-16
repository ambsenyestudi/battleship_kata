# How to setup your project for tdd on vs code

All you need is at micrsoft documentation on dotnet new

https://docs.microsoft.com/es-es/dotnet/core/tools/dotnet-new?tabs=netcore21

#Creating your new assets

To create your new asset you would only need to do the following
I follow the name convention [SolutionName].[ProjectIdentifier] but you are free to follow your own.

dotnet new classlib -n [SolutionName].[YourDomainIdentifier]
dotnet new xunit -n [SolutionName].[YourTestIdentifier]
dotnet new sln -n [SolutionName]

After creating our projects we now need to refrence domain from test. You can read about it here:

https://docs.microsoft.com/es-es/dotnet/core/tools/dotnet-add-reference

As an example following the previous step it would be something like this. Given that you are at base folder you would go like:

dotnet add .\[SolutionName].[YourTestIdentifier]\[SolutionName].[YourTestIdentifier].csproj reference .\[SolutionName].[YourDomainIdentifier]\[SolutionName].[YourDomainIdentifier].csproj

#Add projects to your solution

https://docs.microsoft.com/es-es/dotnet/core/tools/dotnet-sln

dotnet sln .\ [SolutionName] add .\[SolutionName].[YourDomainIdentifier]\[SolutionName].[YourDomainIdentifier].csproj

dotnet sln .\ [SolutionName] add .\[SolutionName].[YourTestIdentifier]\[SolutionName].[YourTestIdentifier].csproj

Finally run:
dotnet restore
This will link it all togheter, then write a test that uses a domain class and run :
dotnet build
After that run
dotnet test

And you are good to go.
