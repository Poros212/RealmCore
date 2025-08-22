using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.UI.ConsoleApp
{
    using Spectre.Console;
    using Spectre.Console.Rendering;

    public static class ConsoleWindow
    {
        /// <summary>
        /// Renders a 3-column layout (Left fixed, Center flex, Right fixed).
        /// Each region is wrapped in an expanded Panel so it fills full height.
        /// Pass delegates that print (Console.Write/WriteLine) or return strings.
        /// </summary>
        public static void RenderThreeColumn(
            Action? left = null,
            Action? center = null,
            Action? right = null,
            int leftWidth = 28,
            int rightWidth = 28,
            string? leftTitle = null,
            string? centerTitle = null,
            string? rightTitle = null,
            BoxBorder? leftBorder = null,
            BoxBorder? centerBorder = null,
            BoxBorder? rightBorder = null)
        {
            var layout = new Layout("root")
                .SplitColumns(
                    new Layout("left").Size(leftWidth),
                    new Layout("center"),
                    new Layout("right").Size(rightWidth));

            layout["left"].Update(MakePanel(Capture(left), leftTitle, leftBorder ?? BoxBorder.Rounded, expand: true));
            layout["center"].Update(MakePanel(Capture(center), centerTitle, centerBorder ?? BoxBorder.Rounded, expand: true));
            layout["right"].Update(MakePanel(Capture(right), rightTitle, rightBorder ?? BoxBorder.Rounded, expand: true));

            AnsiConsole.Clear();
            AnsiConsole.Write(layout);
        }

        private static IRenderable MakePanel(string text, string? title, BoxBorder border, bool expand)
        {
            var panel = new Panel(new Text(text)) // Text = literal (no markup parsing)
                .Border(border);
            if (!string.IsNullOrWhiteSpace(title))
                panel.Header(title);
            if (expand)
                panel.Expand();   // <-- makes it fill region height
            return panel;
        }

        // Capture Console.Write/WriteLine output from your methods
        private static string Capture(Action? writer)
        {
            if (writer is null) return string.Empty;
            var original = Console.Out;
            var sb = new System.Text.StringBuilder();
            using var sw = new StringWriter(sb);
            try
            {
                Console.SetOut(sw);
                writer();
            }
            finally
            {
                Console.SetOut(original);
            }
            return sb.ToString();
        }
    }
}