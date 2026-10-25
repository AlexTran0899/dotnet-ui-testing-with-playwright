using System.ComponentModel;
using Microsoft.Playwright;

public static class BrowserConfigExtensions
{
    public static BrowserTypeLaunchOptions Headless(
        this BrowserTypeLaunchOptions options, bool enabled = true)
    {
        options.Headless = enabled;
        return options;
    }

    public static BrowserTypeLaunchOptions SlowMo(
        this BrowserTypeLaunchOptions options, float milliseconds)
    {
        options.SlowMo = milliseconds;
        return options;
    }

    public static BrowserTypeLaunchOptions Channel(this BrowserTypeLaunchOptions options, BrowserType browserType)
    {
        options.Channel = browserType.GetValue();
        return options;
    }

    public static string GetEngine(this BrowserTypeLaunchOptions options)
    {
        return options.Channel switch
        {
            var c when c == BrowserType.Chrome.GetValue() => "chromium",
            var c when c == BrowserType.Edge.GetValue() => "chromium",
            var c when c == BrowserType.Firefox.GetValue() => "firefox",
            var c when c == BrowserType.WebKit.GetValue() => "webkit",
            _ => "chromium"
        };
    }
}



