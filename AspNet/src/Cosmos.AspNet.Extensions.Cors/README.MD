# Cosmos.AspNet.Extensions.Cors

## Usage

First, set cors policy to global filters:

``` c#
public class FilterConfig
{
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.AddCorsFilter(options =>
        {
            options.AddPolicy("MyFirstCorsFilter", builder => builder.AllowAnyOrigin());
            options.AddPolicy("MySecondCorsFilter", builder => builder.AllowAnyMethod());

            options.DefaultPolicyName = "MyFirstCorsFilter";
            //options.EnableGlobalCors = true;
            //options.GlobalCorsPolicyName = "MyFirstCorsFilter";
        });
    }
}
```

then use it as attribute:

``` c#
[Cors]
public ActionResult CorsDemo() 
    => Content("CORS: OK");
```

or

``` c#
[Cors(policyName: "MyFirstCorsFilter")]
public ActionResult CorsDemo() 
    => Content("CORS: OK");
```

or you can use it as global filter:

``` c#
public class FilterConfig
{
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.AddCorsFilter(options =>
        {
            options.AddPolicy("MyFirstCorsFilter", builder => builder.AllowAnyOrigin());
            options.AddPolicy("MySecondCorsFilter", builder => builder.AllowAnyMethod());

            options.DefaultPolicyName = "MyFirstCorsFilter";
            options.EnableGlobalCors = true;
            //options.GlobalCorsPolicyName = "MyFirstCorsFilter";
        });
    }
}
```

that's all.

* * *

[MIT](https://mit-license.org/)