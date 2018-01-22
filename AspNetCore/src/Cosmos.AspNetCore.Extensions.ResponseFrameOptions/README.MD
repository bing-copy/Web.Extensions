# Cosmos.AspNetCore.Extensions.ResponseFrameOptions

## Usage

use it as attribute:

``` c#
[FrameOptions(FrameOptions = ResponseFrameOptionsType.DENY)]
public IActionResult XFrameOptions() 
    => Content("X-Frame-Options: OK");
```

or you can use it as asp.net core middleware (likes global attribute):


``` c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddResponseFrameOptions();
}
```

``` c#
public void Configure(IApplicationBuilder app)
{
    app.UseResponseFrameOptions(ResponseFrameOptionsType.SAMEORIGIN);

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