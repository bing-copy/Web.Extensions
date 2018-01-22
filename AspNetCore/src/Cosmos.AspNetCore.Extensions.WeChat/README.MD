# Cosmos.AspNetCore.Extensions.WeChat

## Usage

use it as attribute:

``` c#
[WeChatBrowserOnly]
public IActionResult WeChatOnly()
    => Content("Hello WeChat User");
```

or you can use it as asp.net core middleware (likes global attribute):

``` c#
public void Configure(IApplicationBuilder app)
{
    app.UseWeChatBrowserOnly();

    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
    });
}
```

that's all.

* * *

[MIT](https://mit-license.org/)