using System.Threading.Channels;
using Microsoft.Playwright;
using NuGet.Packaging.Signing;
using SQLitePCL;

namespace ui_test;

public class UnitTest1 : IAsyncLifetime, IClassFixture<PlaywrightDriver>
{
    private PlaywrightDriver _driver = null!;
    private IBrowserContext _context = null!;
    private IPage _page = null!;

    public UnitTest1(PlaywrightDriver playWrightDriver)
    {
        _driver = playWrightDriver;
    }

    public async Task InitializeAsync()
    {
        var options = new BrowserTypeLaunchOptions()
            .Headless(false);
        _context = await _driver.CreateContextAsync(options);
        _page = await _context.NewPageAsync();
    }

    public async Task DisposeAsync()
    {
        await _context.CloseAsync();
    }

    [Fact]
    public async Task Test1()
    {
        await _page.GotoAsync("https://www.google.com");
    }

    [Fact]
    public async Task Test2()
    {
        await _page.GotoAsync("https://www.google.com");

    }
}
