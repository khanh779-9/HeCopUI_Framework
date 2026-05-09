using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.TextControl
{
    /// <summary>
    /// Simple Markdown viewer based on the built‑in WebBrowser control.
    /// It renders the supplied markdown as HTML. If the project references
    /// the Markdig NuGet package, the markdown will be converted to HTML;
    /// otherwise the raw markdown text is displayed.
    /// </summary>
    public class MarkdownView : UserControl
    {
        private readonly WebBrowser _browser;

        public MarkdownView()
        {
            // Apply the same visual style as other HeCopUI controls
            SetStyle(GetAppResources.SetControlStyles(), true);
            _browser = new WebBrowser { Dock = DockStyle.Fill, AllowWebBrowserDrop = false };
            Controls.Add(_browser);
        }

        /// <summary>
        /// Loads markdown text and displays it as HTML.
        /// </summary>
        /// <param name="markdown">Markdown source string.</param>
        public void LoadMarkdown(string markdown)
        {
            string html;
            try
            {
                // If Markdig is available, use it for conversion
                var markdownType = Type.GetType("Markdig.Markdown, Markdig");
                if (markdownType != null)
                {
                    var toHtmlMethod = markdownType.GetMethod("ToHtml", new[] { typeof(string) });
                    html = (string)toHtmlMethod.Invoke(null, new object[] { markdown });
                }
                else
                {
                    // Fallback: wrap markdown in a <pre> block
                    html = $"<pre>{System.Web.HttpUtility.HtmlEncode(markdown)}</pre>";
                }
            }
            catch
            {
                // In case of any conversion error, show raw text safely escaped
                html = $"<pre>{System.Web.HttpUtility.HtmlEncode(markdown)}</pre>";
            }

            _browser.DocumentText = html;
        }
    }
}