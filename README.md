ArgumentContracts
=================
Helper methods for validating method arguments in .NET 4 and upwards.

Similar to the Code Contracts feature, but even easier to use.

### Validators ###
Currently the ArgumentContracts package only supports argument value requirement.

I.e. the equivalent of this:

    public void DoSomething(string id)
    {
        if (id == null) 
        {
            throw new ArgumentNullException("id");
        }
    }
    
You can also create your own validators for your custom classes by implementing the `ITypedArgumentValidator<T>` interface.

The register your validators like this:
    
    ArgumentValidators.Instance.Add(new MyValidator());

NOTE: The default behavior when validating strings is to use the `string.IsNullOrEmpty` method which means it will throw an exception on empty string values.

To avoid this you need to replace the built-in `StringArgumentValidator` like this:

    ArgumentValidators.Instance.Replace(typeof(StringArgumentValidator), new StringArgumentValidator(true));

### How to use ###
    public void DoSomething(string id)
    {
        Argument.Require(() => id);
    }