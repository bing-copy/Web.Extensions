# Cosmos.Nancy.Extensions.Cors

## Usage

use it as global filter in *Bootstrapper*:

``` c#
protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
{
    pipelines.UseCors(options =>
    {
        options.AddPolicy("MyFirstCorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod());

        options.DefaultPolicyName = "MyFirstCorsPolicy";
        options.EnableGlobalCors = true;
        options.GlobalCorsPolicyName = "MyFirstCorsPolicy";
    });
}
```

that's all.

* * *

[MIT](https://mit-license.org/)