# Cosmos.AspNetCore.Extensions.AntiXss

## Usage

first

``` c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddAntiXss();
}
```

and then

``` c#
[AntiXss]
public IActionResult YourAction(SomeModel model)
{
    //...
}
```

that's all.

* * *

[MIT](https://mit-license.org/)