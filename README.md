

# ASP.NET Core WebAPI Action Parameters Validation

There are two types of guards:
- The enforcers, as the name suggests, enforce an argument to be within the check limits by throwing an EnforcerException if they fail. By adding the `EnforcerMiddleware` each exception is handled and a 400 BadRequest is returned. You can also create your own Exception by implementing the `IEnforcerException` interface, or inheriting from the `EnforcerException` type.
- The Checks, a simpler version that just check and return true or false depending on the check success or failure

>  It is generally a very bad idea to use exceptions to control flow, and the use of the enforcers can contribute to this anti-pattern. Use them specifically for what they are designed, preferably at the top of each action, clearly separated from the rest of your code!
Read this for more details: https://web.archive.org/web/20140430044213/http://c2.com/cgi-bin/wiki?DontUseExceptionsForFlowControl

## Usage  

### Guards sample  
```
public async Task<IActionResult> Get(Guid projectId, int skip, int take, string query)
{
	//Enforcers
    	Guard.Object.IsNotNullOrDefault(projectId, "ProjectId");
    	Guard.Numeric.IsGreaterOrEqualThan(skip, 0, "Skip");	
	
	//Checks
	if( !Check.Numeric.IsBetweenInclusive(0, 1, 3, "RandomNumber") )
	     //Check failed
	//...
}
```

## Enforcers included  
Enforcers throw an `IEnforcerException` when something is wrong. Please use the Enforcer middleware to transparently catch this exception and return a 400

### Bool Enforcers 
 - `IsTrue(bool value, string message)`
 - `IsFalse(bool value, string message)`
 
### Numeric Enforcers 
 - `IsGreaterThan<T>(T value, T than, string message) where T : IComparable`
 - `IsGreaterOrEqualThan<T>(T value, T than, string message) where T : IComparable`
 - `IsSmallerThan<T>(T value, T than, string message) where T : IComparable`
 - `IsSmallerOrEqualThan<T>(T value, T than, string message) where T : IComparable`
 - `IsBetweenInclusive<T>(T value, T from, T to, string message) where T : IComparable`
 - `IsBetweenExclusive<T>(T value, T from, T to, string message) where T : IComparable`
 
### Object Enforcers  
 - `AreEqual<T>(T obj1, T obj2, string message) where T : IComparable`
 - `AreNotEqual<T>(T obj1, T obj2, string message) where T : IComparable`
 - `IsNullOrDefault<T>(T value, string message)`
 - `IsNotNullOrDefault<T>(T value, string message)`
 - `IsDefined<T>(T value, string message)`
 - `IsNotDefined<T>(T value, string message)`

### String Enforcers  
 - `IsNullOrEmpty(string value, string message)`  
 - `IsNotNullOrEmpty(string value, string message)`  
 - `IsNullOrWhiteSpace(string value, string message)`  
 - `IsNotNullOrWhiteSpace(string value, string message)`  
 - `IsNull(string variable, string message)`
 - `IsNotNull(string variable, string message)`
 
## Enforcer middleware  
In order for the enforcers to work correctly, you need to add the enforcer middleware in the pipeline.
The middleware will handle all exceptions that implement the `IEnforcerException` interface.

### Add the handling middleware in Startup.cs  
```
public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
    //...
    app.AddEnforcerMiddleware();//Position is important, it has to be before other middlewares
    //...
    app.UseAuthentication();
    app.UseMvc();
}
```
### Enforcer exception model  
TODO: Describe the exception model returned

## Extending enforcers  
There is no way to actually extend the enforcers by adding new, but you can create a custom exception that implements the empty `IEnforcerException` interface. 
Throwing that custom exception will cause the enforcer middleware to catch the exception and return the serialized model of that.
 
## Checks included  
The checks don't throw anything! They just return false when something is wrong and true if check succeeds!

### Bool Checks
- `IsTrue(bool value)`
 - `IsFalse(bool value)` 

### Numeric Checks
- `AreEqual<T>(T obj1, T obj2) where T : IComparable`
 - `IsGreaterThan<T>(T value, T than) where T : IComparable`
 - `IsSmallerThan<T>(T value, T than) where T : IComparable` 
 - `IsBetweenInclusive<T>(T value, T from, T to) where T : IComparable`
 - `IsBetweenExclusive<T>(T value, T from, T to) where T : IComparable`

### Object Checks
- `AreEqual<T>(T value1, T value2) where T : IComparable`
- `IsNull<T>(T value)`
- `IsNull<T>(T? value) where T : struct`
- `IsDefault<T>(T value)`
- `IsDefined<T>(T value) where T : struct`

### String Checks
 - `IsNullOrEmpty(string value)`
 - `IsNullOrWhiteSpace(string value)`
 - `IsNull(string value)`
