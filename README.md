# clean-architecture

### Usage

1. Clone this repository

2. Run "Install Template" bat file it will install roptia template :


3. To check that the template has been installed successfully:

```
dotnet new -l
```

- There should now be a new template **nice.CA**

```
Templates                                          Short Name                 Language          Tags
----------------------------------------------------------------------------------------------------------
.NET Core 6.0 Template 						       nice.CA      [C#]              Web/API/Microservices
```

4. To Create the .Net Core Solution by using Template use below instructions. 


```
dotnet new nice.CA  -n {{Namespace_of_your_project}} --Port 44550  --Sslport 44551     
```

- This will create the folder containing a solution and project folder.

