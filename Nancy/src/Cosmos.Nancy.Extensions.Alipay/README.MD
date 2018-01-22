# Cosmos.Nancy.Extensions.Alipay

## Usage

use it in module:

``` c#
public class HomeModule : NancyModule
{
    public HomeModule()
    {
        base.Before.UseAlipayBrowserOnly();
        Get("/home/alipayonly", args => "Hello Alipay");
    }
}
```

or you can use it as global filter in *Bootstrapper*:

``` c#
protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
{
    pipelines.UseAlipayBrowserOnly();
}
```

that's all.

* * *

[MIT](https://mit-license.org/)