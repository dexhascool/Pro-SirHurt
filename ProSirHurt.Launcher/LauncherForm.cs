using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSirHurt.Launcher
{
    public partial class LauncherForm : Form
    {
        public LauncherForm()
        {
            InitializeComponent();
            this.Load += LauncherForm_Load;
        }

        private async void LauncherForm_Load(object sender, EventArgs e)
        {
            try
            {
                await RunBootstrapperAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bootstrap error: {ex.Message}");
            }
        }

        private async Task RunBootstrapperAsync()
        {
            var client = new HttpClient();
            string version = "V1.11";
            long ts = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            string baseApp = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "ProSirHurt"
            );
            Directory.CreateDirectory(baseApp);

            // Fetch manifest
            string manifestUrl = $"https://sirhurt.net/asshurt/update/v5/fetch_bootstrapper_list.php?version={version}&timestamp={ts}";
            string json = await client.GetStringAsync(manifestUrl);
            var entries = JsonSerializer.Deserialize<List<FileEntry>>(json);

            int total = entries.Count(e => !e.filename.Equals("SirHurt UI.zip", StringComparison.OrdinalIgnoreCase));
            int done = 0;

            foreach (var e in entries)
            {
                // Skip default UI zip since using custom UI
                if (e.filename.Equals("SirHurt UI.zip", StringComparison.OrdinalIgnoreCase))
                    continue;

                string url;
                bool isHexStream = false;
                if (e.downloadfromlink)
                {
                    url = $"{e.linktodownload}?customversion={version}&timestamp={ts}";
                }
                else if (e.protectFile)
                {
                    string fileParam = WebUtility.UrlEncode(e.filename);
                    string verArg = e.specifyRobloxVersionInLink ? $"customversion={version}&" : string.Empty;
                    url = $"https://sirhurt.net/asshurt/update/v5/ProtectFile.php?{verArg}file={fileParam}&timestamp={ts}";
                    isHexStream = true;
                }
                else
                {
                    url = $"https://sirhurt.net/asshurt/update/v5/{e.filename}?timestamp={ts}";
                }

                string outPath = Path.Combine(baseApp, e.saveas);

                // Download
                if (isHexStream)
                {
                    var hex = await client.GetStringAsync(url);
                    // server returns reversed hex
                    var rev = new string(hex.Reverse().ToArray());
                    var bytes = ConvertHexStringToByteArray(rev);
                    await File.WriteAllBytesAsync(outPath, bytes);
                }
                else
                {
                    using var resp = await client.GetAsync(url);
                    resp.EnsureSuccessStatusCode();
                    await using var fs = File.Create(outPath);
                    await resp.Content.CopyToAsync(fs);
                }

                // MD5 retry if needed
                if (e.updateIfMD5Mismatch && !ComputeMd5(outPath).Equals(e.md5checksum, StringComparison.OrdinalIgnoreCase))
                {
                    // retry once
                    if (isHexStream)
                    {
                        var hex2 = await client.GetStringAsync(url);
                        var rev2 = new string(hex2.Reverse().ToArray());
                        var bytes2 = ConvertHexStringToByteArray(rev2);
                        await File.WriteAllBytesAsync(outPath, bytes2);
                    }
                    else
                    {
                        using var r2 = await client.GetAsync(url);
                        r2.EnsureSuccessStatusCode();
                        await using var fs2 = File.Create(outPath);
                        await r2.Content.CopyToAsync(fs2);
                    }
                }

                // Extract zip files
                if (e.extract)
                {
                    try
                    {
                        ZipFile.ExtractToDirectory(outPath, baseApp, overwriteFiles: true);
                    }
                    catch (InvalidDataException)
                    {
                        // Not a valid zip archive; skip extraction
                    }
                }

                // Progress
                done++;
                progressBar1.Value = done * 100 / total;
                label1.Text = $"Updating... {done}/{total}";
                Application.DoEvents();

                // Launch after download
                if (e.runAfterDownload)
                {
                    Process.Start(Path.Combine(baseApp, e.runAfterDownloadFileName));
                }
            }

            label1.Text = "All set!";
        }

        private string ComputeMd5(string path)
        {
            using var md5 = MD5.Create();
            using var stream = File.OpenRead(path);
            var hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
        }

        private byte[] ConvertHexStringToByteArray(string hex)
        {
            int len = hex.Length;
            byte[] bytes = new byte[len / 2];
            for (int i = 0; i < len; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private class FileEntry
        {
            public string filename { get; set; }
            public bool extract { get; set; }
            public bool downloadfromlink { get; set; }
            public bool runAfterDownload { get; set; }
            public string runAfterDownloadFileName { get; set; }
            public string saveas { get; set; }
            public string linktodownload { get; set; }
            public bool specifyRobloxVersionInLink { get; set; }
            public bool protectFile { get; set; }
            public bool updateIfMD5Mismatch { get; set; }
            public string md5checksum { get; set; }
        }
    }
}
