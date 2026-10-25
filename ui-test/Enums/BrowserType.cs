using System.ComponentModel;

public enum BrowserType
{
    [Description("chrome")]
    Chrome,

    [Description("msedge")]
    Edge,

    [Description("firefox")]
    Firefox,

    [Description("webkit")]
    WebKit
}