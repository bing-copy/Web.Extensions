# Cosmos.AspNet.Extensions.Alipay

## Usage

use it as attribute:

``` c#
[AlipayBrowserOnly]
public ActionResult AlipayOnly()
    => Content("Hello Alipay User");
```

or you can use it as global filter:

``` c#
public class FilterConfig
{
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.AddAlipayBrowserFilter();
    }
}
```

that's all.

* * *

[MIT](https://mit-license.org/)