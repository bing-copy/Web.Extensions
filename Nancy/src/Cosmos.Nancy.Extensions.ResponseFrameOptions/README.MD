# Cosmos.Nancy.Extensions.ResponseFrameOptions

## Usage

use it in module:

``` c#
public class HomeModule : NancyModule
{
    public HomeModule()
    {
        base.After.UseResponseFrameOptions();
        Get("home/framedemo", args => "X-Frame-Options: OK");
    }
}
```

or you can use it as global filter in *Bootstrapper*:

``` c#
protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
{
    pipelines.UseResponseFrameOptions();
}
```

that's all.

* * *

[MIT](https://mit-license.org/)