using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentospectMobileApp.Services
{
    public class DrawingViewExportService
    {
        /// <summary>
        /// Creates a temporary DrawingView, assigns the supplied lines and returns an image stream.
        /// width/height are the output image pixel dimensions (or DPI-adjusted values).
        /// </summary>
        public static async Task<Stream> ExportAsync(
            IEnumerable<IDrawingLine> lines,
            int width = 300,
            int height = 200)
        {
            if (lines == null || !lines.Any())
                throw new ArgumentException("No drawing lines provided.", nameof(lines));

            // Make a DrawingView instance and set its Lines collection.
            // Note: Creating a DrawingView here is OK for exporting; it will not be attached to the visual tree.
            var drawingView = new DrawingView
            {
                Lines = new ObservableCollection<IDrawingLine>(lines),
                BackgroundColor = Microsoft.Maui.Graphics.Colors.White,
                LineColor = Microsoft.Maui.Graphics.Colors.Black
            };

            // GetImageStream (or GetImageStreamAsync depending on toolkit version).
            // Try GetImageStream first, fallback to GetImageStreamAsync if necessary.
            try
            {
                // Common method in many toolkit versions:
                var stream = await drawingView.GetImageStream(width, height);
                return stream;
            }
            catch (MissingMethodException)
            {
                // If your toolkit version exposes an Async variant, use that:
                var method = typeof(DrawingView).GetMethod("GetImageStreamAsync");
                if (method != null)
                {
                    var task = (Task<Stream>)method.Invoke(drawingView, new object[] { width, height });
                    return await task;
                }
                throw; // rethrow if neither method is present
            }
        }
    }
}
