# Cosmos.AspNet.Extensions.ResponseCompression

## Usage

use it as attribute:

``` c#
[Compression]
public ActionResult CompressionDemo()
    => Content("Compression balabala~");
```

or you can use it as global filter:

``` c#
public class FilterConfig
{
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.AddResponseCompressionFilter();
    }
}
```

that's all.

* * *

[MIT](https://mit-license.org/)