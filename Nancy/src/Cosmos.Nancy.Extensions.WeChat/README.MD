# Cosmos.Nancy.Extensions.WeChat

## Usage

use it in module:

``` c#
public class HomeModule : NancyModule
{
    public HomeModule()
    {
        base.Before.UseWeChatBrowserOnly();
        Get("/home/wechatonly", args => "Hello WeChat");
    }
}
```

or you can use it as global filter in *Bootstrapper*:

``` c#
protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
{
    pipelines.UseWeChatBrowserOnly();
}
```

that's all.

* * *

[MIT](https://mit-license.org/)