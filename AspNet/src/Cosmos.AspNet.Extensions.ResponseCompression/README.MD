# Cosmos.AspNet.Extensions.ResponseCompression

## Usage

for compossion, use it as attribute:

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

for minification, use it as attribute:

``` c#
[Minification]
public ActionResult MinificationDemo()
    => Content(@"<h1>        Hello       World!      </h1>
                             <p>   <h2>tag</h2>    <h2>tag2  tag3   </h2></p>")
```

or you can use it as global filter:

``` c#
public class FilterConfig
{
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
        filters.AddResponseMinificationFilter();
    }
}
```

that's all.

* * *

[MIT](https://mit-license.org/)