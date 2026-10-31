using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;
using Microsoft.Playwright;
namespace ui_test;

using static Microsoft.Playwright.Assertions;
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
    public async Task TestWebsite()
    {
        await _page.GotoAsync("https://www.alextranwebsite.com/");

        // Verify headings
        await AssertClickableAsync(_page.GetByRole(
            AriaRole.Heading,
            new() { Name = "👋 Howdy" }
        ));

        // Verify description
        await AssertClickableAsync(_page.GetByText(
            "I build web and mobile apps"
        ));

        // Verify navigation buttons
        await AssertClickableAsync(_page.GetByRole(
            AriaRole.Button,
            new() { Name = " Github" }
        ));

        await AssertClickableAsync(_page.GetByRole(
            AriaRole.Button,
            new() { Name = " Résumé" }
        ));

        await AssertClickableAsync(_page.GetByRole(
            AriaRole.Button,
            new() { Name = " Leetcode" }
        ));

        // Verify profile image
        await AssertClickableAsync(_page.GetByRole(
            AriaRole.Img,
            new() { Name = "picture of Alex Tran" }
        ));

        // Verify Niagara Falls heading
        await AssertClickableAsync(_page.GetByRole(
            AriaRole.Heading,
            new() { Name = "Alex at Niagara Falls" }
        ));
    }

    private static async Task AssertClickableAsync(ILocator element)
    {
        await Expect(element).ToBeVisibleAsync();
        await Expect(element).ToBeEnabledAsync();

        // Verify clickability without actually clicking
        // await element.ClickAsync(new()
        // {
        //     Trial = true
        // });

        await element.ClickAsync();
    }
}

