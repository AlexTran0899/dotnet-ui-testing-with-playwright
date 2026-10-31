using Microsoft.Playwright;

public class PlaywrightDriver : IAsyncLifetime
{
    private IPlaywright _playwright = null!;
    private readonly List<IBrowser> _browsers = new();

    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();
    }

    public async Task DisposeAsync()
    {
        foreach (var browser in _browsers)
        {
            await browser.CloseAsync();
        }

        _playwright.Dispose();
    }

    public async Task<IBrowserContext> CreateContextAsync(
     BrowserTypeLaunchOptions options)
    {

        var browser = await _playwright[options.GetEngine()].LaunchAsync(options);

        _browsers.Add(browser);

        return await browser.NewContextAsync();
    }
}