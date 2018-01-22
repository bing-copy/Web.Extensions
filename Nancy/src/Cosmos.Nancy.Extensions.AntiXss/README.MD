# Cosmos.Nancy.Extensions.AntiXss

## Usage

use it as global filter in *Bootstrapper*:

``` c#
protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
{
    pipelines.UseAntiXss(options =>
    {
        options.AddPolicy("MyFirstAntiXSSPolicy", builder => builder.WithUriQueryKeys("Parameters"));
        options.DefaultPolicyName = "MyFirstAntiXSSPolicy";
    });
}
```

here, you should put each parameter's key in policy.

``` c#
public class HomeModule : NancyModule
{
    public HomeModule()
    {
        Get("home/antixss", args => $"AntiXSS: {this.Request.Query["Parameters"]}");
    }
}
```

enter this url `http://localhost:61626/home/antixss?Parameters=1|<script>alert('1');</script>|123` in your browser's address bar,

as result

``` txt
AntiXSS: 1||123
```

that's all.

* * *

[MIT](https://mit-license.org/)