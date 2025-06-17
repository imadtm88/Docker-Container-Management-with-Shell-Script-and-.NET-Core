using System.Diagnostics;

namespace WebAPI.Service
{
    public class ShellService
    {
        public async Task<string> RunScriptAsync(string scriptPath, string args = "")
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"{scriptPath} {args}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();
            process.WaitForExit();

            return string.IsNullOrWhiteSpace(error) ? output : $"Error: {error}";
        }
    }
}
