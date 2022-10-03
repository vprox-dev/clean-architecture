# clean-architecture

### Usage

1. Clone this repository

2. Install Template on your system.  Open CMD in Downloaded Path. 
	
```
dotnet new -i clean-architecture
```	


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



5. Optional Step To Uninstall the template

```
dotnet new --uninstall clean-architecture
``` 
	

