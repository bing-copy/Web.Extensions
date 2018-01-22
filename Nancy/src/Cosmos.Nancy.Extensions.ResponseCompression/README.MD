# Cosmos.Nancy.Extensions.ResponseCompression

迁移自 [Nancy.Gzip](https://github.com/dcomartin/Nancy.Gzip) 

## General Usage

Enable gzip compression in your bootstrapper.

```c#
public class Bootstrapper : DefaultNancyBootstrapper
{
    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    {
        // Use Compression with Default Settings
        pipelines.UseResponseCompression(options => options.CompressionScheme = CompressionScheme.Gzip);

        base.ApplicationStartup(container, pipelines);
    }
}
```


## Options

There are only two setings in which you can configure

### Minimum Bytes

The default minimum size (Content-Length) of output before it will be compressed is 4096.  If the size is below this amount, it will not be compressed.

### Mime Types

There are default mime types which specify which mime types are valid for compression.  You can add your own content types to this list.

The defaults are:

* text/plain
* text/html
* text/xml
* text/css
* application/json
* application/x-javascript
* application/atom+xml

### Settings Example 

```c#
public class Bootstrapper : DefaultNancyBootstrapper
{
    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    {
        // Enable Compression with Settings
        pipelines.UseResponseCompression(options =>
        {
            options.MinimumBytes = 1024;
            options.MimeTypes.Add("application/vnd.myexample");
            options.CompressionScheme = CompressionScheme.Gzip;
        });

        base.ApplicationStartup(container, pipelines);
    }
}
```

```c#
public class Bootstrapper : AutofacNancyBootstrapper
{
    protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
    {
       pipelines.UseResponseCompression(options => options.CompressionScheme = CompressionScheme.Gzip);

       base.ApplicationStartup(container, pipelines);
    }
}
```


that's all.

* * *

[MIT](https://mit-license.org/)