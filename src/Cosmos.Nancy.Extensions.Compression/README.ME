# Cosmos.Nancy.Extensions.Compression

迁移自 [Nancy.Gzip](https://github.com/dcomartin/Nancy.Gzip) 

## General Usage

Enable gzip compression in your bootstrapper.

```C#
public class Bootstrapper : DefaultNancyBootstrapper
{
    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    {
        // Enable Compression with Default Settings
        pipelines.EnableGzipCompression();

        base.ApplicationStartup(container, pipelines);
    }
}
```


## Settings

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
```C#
public class Bootstrapper : DefaultNancyBootstrapper
{
    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    {
        // Enable Compression with Settings
        var settings = new CompressionSettings();
        settings.MinimumBytes = 1024;
        settings.MimeTypes.Add("application/vnd.myexample");
        pipelines.EnableGzipCompression(settings);

        base.ApplicationStartup(container, pipelines);
    }
}
```