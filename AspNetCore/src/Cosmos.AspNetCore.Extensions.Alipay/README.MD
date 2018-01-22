# Cosmos.AspNetCore.Extensions.Alipay

## Usage

use it as attribute:

``` c#
[AlipayBrowserOnly]
public IActionResult AlipayOnly()
    => Content("Hello Alipay User");
```

or you can use it as asp.net core middleware (likes global attribute):

``` c#
public void Configure(IApplicationBuilder app)
{
    app.UseAlipayBrowserOnly();

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