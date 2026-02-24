using System;
using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Diagnostics;
using System.Linq;

namespace WordPressBackupTool;

class Program
{
    private static DateTime? _lastBackupDate = null;

    static async Task Main(string[] args)
    {
        string mode = args.Length > 0 ? args[0].ToLower() : "daemon";

        if (mode == "run")
        {
            Console.WriteLine("[INFO] Manual run triggered...");
            ExecuteAllBackups();
        }
        else
        {
            Console.WriteLine("[INFO] Daemon started. Monitoring time...");
            while (true)
            {
                CheckAndRunBackup();
                // Sleep to save CPU (configured in config.json)
                await Task.Delay(20000); 
            }
        }
    }

    static void CheckAndRunBackup()
    {
        var config = LoadConfig();
        if (config == null) return;

        TimeSpan targetTime = TimeSpan.Parse(config.General.BackupTime);
        DateTime now = DateTime.Now;

        // Condition: Is it past the scheduled time AND have we NOT backed up today?
        if (now.TimeOfDay >= targetTime && _lastBackupDate?.Date != now.Date)
        {
            ExecuteAllBackups();
            _lastBackupDate = now;
        }
    }

    static void ExecuteAllBackups()
    {
        var config = LoadConfig();
        if (config == null) return;

        foreach (var site in config.Sites.Where(s => s.Enabled))
        {
            try
            {
                Console.WriteLine($"\n--- Processing Site: {site.SiteName} ---");
                
                // 1. Setup paths
                string timestamp = DateTime.Now.ToString(config.General.DateTimeFolderFormat);
                string siteRoot = Path.Combine(config.General.BackupRootPath, site.SiteName);
                string currentBackupDir = Path.Combine(siteRoot, timestamp);
                Directory.CreateDirectory(currentBackupDir);

                // 2. Zip Files
                string zipName = $"{site.SiteName}_{timestamp}_files.zip";
                string zipPath = Path.Combine(currentBackupDir, zipName);
                Console.WriteLine($"[ZIP] Creating: {zipName}");
                ZipFile.CreateFromDirectory(site.Wordpress.RootPath, zipPath);

                // 3. MySQL Dump
                string sqlName = $"{site.SiteName}_{timestamp}_db.sql";
                string sqlPath = Path.Combine(currentBackupDir, sqlName);
                RunMySqlDump(config, site, sqlPath);

                // 4. Retention (Keep Last N)
                ApplyRetention(siteRoot, site.KeepLast);
                
                Console.WriteLine($"[SUCCESS] Completed: {site.SiteName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed site {site.SiteName}: {ex.Message}");
            }
        }
    }

    static void RunMySqlDump(Config config, Site site, string outputPath)
    {
        string host = site.Database.Host ?? config.General.Mysql.DefaultHost;
        string passArg = string.IsNullOrEmpty(site.Database.Password) ? "" : $"-p{site.Database.Password}";

        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = config.General.Mysql.MysqldumpPath,
            // Using -r for output and making sure there are no weird spaces
            Arguments = $"-h {host} -u {site.Database.Username} {passArg} {site.Database.DbName} -r \"{outputPath}\"",
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Console.WriteLine($"[SQL] Executing: mysqldump {site.Database.DbName}...");

        using var process = Process.Start(psi);
        // This will stop it from hanging forever (2-minute limit)
        if (process.WaitForExit(120000)) 
        {
            if (process.ExitCode != 0)
            {
                string error = process.StandardError.ReadToEnd();
                Console.WriteLine($"[SQL ERROR] {error}");
            }
            else
            {
                Console.WriteLine("[SQL] Database dump successful.");
            }
        }
        else
        {
            process.Kill();
            Console.WriteLine("[SQL ERROR] Process timed out after 2 minutes. Check your DB credentials!");
        }
    }

    static void ApplyRetention(string siteFolder, int keepLast)
    {
        var directories = Directory.GetDirectories(siteFolder)
            .Select(d => new DirectoryInfo(d))
            .OrderByDescending(d => d.CreationTime)
            .ToList();

        if (directories.Count > keepLast)
        {
            var toDelete = directories.Skip(keepLast);
            foreach (var dir in toDelete)
            {
                Console.WriteLine($"[CLEANUP] Deleting old backup: {dir.Name}");
                dir.Delete(true);
            }
        }
    }

    static Config? LoadConfig() 
    {
        try {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(baseDir, "config.json");
            string json = File.ReadAllText(configPath);
            return JsonSerializer.Deserialize<Config>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        } catch (Exception e) {
            Console.WriteLine("[CRITICAL] Config error: " + e.Message);
            return null;
        }
    }
}

// Data models to match your JSON
public class Config {
    public GeneralSettings General { get; set; }
    public List<Site> Sites { get; set; }
}
public class GeneralSettings {
    public string BackupRootPath { get; set; }
    public string BackupTime { get; set; }
    public string DateTimeFolderFormat { get; set; }
    public MySqlSettings Mysql { get; set; }
}
public class MySqlSettings {
    public string MysqldumpPath { get; set; }
    public string DefaultHost { get; set; }
    public int DefaultPort { get; set; }
}
public class Site {
    public string SiteName { get; set; }
    public bool Enabled { get; set; }
    public int KeepLast { get; set; }
    public WordpressSettings Wordpress { get; set; }
    public DatabaseSettings Database { get; set; }
}
public class WordpressSettings { public string RootPath { get; set; } }
public class DatabaseSettings {
    public string? Host { get; set; }
    public int Port { get; set; }
    public string DbName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}