# Cosmos.AspNet.Extensions.ResponseFrameOptions

## Usage

use it as attribute:

``` c#
[FrameOptions(FrameOptions = ResponseFrameOptionsType.DENY)]
public ActionResult FrameOptions()
    => Content("X-Frame-Options: OK");
```

or you can use it as global filter:

``` c#
public class FilterConfig
{
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.AddResponseFrameOptionsFilter();
    }
}
```

that's all.

* * *

[MIT](https://mit-license.org/)