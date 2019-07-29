using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaveEngine.DirectX11;

namespace ComputeRayTracing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            uint width = 1280;
            uint height = 720;
            using (var test = new RayTracingTest())
            {
                test.Initialize();

                // Create Window
                string windowsTitle = $"{typeof(RayTracingTest).Name}";
                var windowSystem = test.WindowSystem;
                var window = windowSystem.CreateWindow(windowsTitle, width, height);
                test.Surface = window;
                test.FPSUpdateCallback = (fpsString) =>
                {
                    window.Title = $"{windowsTitle}  {fpsString}";
                };

                // Managers
                var swapChainDescriptor = test.CreateSwapChainDescription(window.Width, window.Height);
                swapChainDescriptor.SurfaceInfo = window.SurfaceInfo;

                var graphicsContext = test.CreateGraphicsContext(swapChainDescriptor);
                windowsTitle = $"{windowsTitle} [{graphicsContext.BackendType}]";

                test.Run();
            }
        }
    }
}
