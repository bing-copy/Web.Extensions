# Cosmos.AspNet.Extensions.WeChat

## Usage

use it as attribute:

``` c#
[WeChatBrowserOnly]
public ActionResult WeChatOnly()
    => Content("Hello WeChat User");
```

or you can use it as global filter:

``` c#
public class FilterConfig
{
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.AddWeChatBrowserFilter();
    }
}
```

that's all.

* * *

[MIT](https://mit-license.org/)