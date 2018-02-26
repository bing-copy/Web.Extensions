# Cosmos.AspNetCore.Extensions.ResponseCompression

## Usage

for gzip, use it as asp.net core middleware (likes global attribute):

``` c#
public void Configure(IApplicationBuilder app)
{
    app.UseGzipResponseCompress();

    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
    });
}
```

for minification, use it as asp.net core middleware (likes global attribute):

``` c#
public void Configure(IApplicationBuilder app)
{
    app.UseMinifyResponseCompress();

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