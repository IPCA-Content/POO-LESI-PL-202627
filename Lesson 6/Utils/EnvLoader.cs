//-----------------------------------------------------------------
//    <copyright file="EnvLoader.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>22:40</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

namespace Lesson_6.Utils;

/// <summary>
/// Simple helper to load key=value pairs from a .env file into environment variables.
/// </summary>
public static class EnvLoader
{
    #region Methods

    /// <summary>
    /// Finds and loads key=value pairs from a .env file into environment variables.
    /// Traverses parent directories if necessary to locate the file.
    /// </summary>
    /// <param name="filePath">Optional explicit path to the .env file.</param>
    /// <returns>True if a .env file was found and loaded; otherwise, false.</returns>
    public static bool Load(string? filePath = null)
    {
        string? resolvedPath = ResolveEnvPath(filePath);
        if (resolvedPath == null)
        {
            Console.WriteLine("[EnvLoader] Warning: No .env file found.");
            return false;
        }

        int loadedCount = 0;
        foreach (string line in File.ReadAllLines(resolvedPath))
        {
            string trimmed = line.Trim();
            if (string.IsNullOrWhiteSpace(trimmed) || trimmed.StartsWith('#'))
            {
                continue;
            }

            int separatorIndex = trimmed.IndexOf('=');
            if (separatorIndex <= 0)
            {
                continue;
            }

            string key = trimmed[..separatorIndex].Trim();
            string value = trimmed[(separatorIndex + 1)..].Trim();

            // Strip surrounding quotes if present
            if ((value.StartsWith('"') && value.EndsWith('"')) ||
                (value.StartsWith('\'') && value.EndsWith('\'')))
            {
                value = value[1..^1];
            }

            Environment.SetEnvironmentVariable(key, value);
            loadedCount++;
        }

        Console.WriteLine($"[EnvLoader] Loaded {loadedCount} variables from: {resolvedPath}");
        return true;
    }

    /// <summary>
    /// Locates the .env file in the given path, the current folder, or any parent folder.
    /// </summary>
    /// <param name="explicitPath">Optional explicit path to the .env file.</param>
    /// <returns>The full path of the file, or null if none was found.</returns>
    private static string? ResolveEnvPath(string? explicitPath)
    {
        if (!string.IsNullOrWhiteSpace(explicitPath) && File.Exists(explicitPath))
        {
            return Path.GetFullPath(explicitPath);
        }

        // 1. Check current directory and subfolder
        string currentDir = Directory.GetCurrentDirectory();
        string candidate = Path.Combine(currentDir, ".env");
        if (File.Exists(candidate))
        {
            return candidate;
        }

        candidate = Path.Combine(currentDir, "Lesson 6", ".env");
        if (File.Exists(candidate))
        {
            return candidate;
        }

        // 2. Traverse up from AppContext.BaseDirectory (handles bin/Debug/net10.0 in Rider)
        string? dir = AppContext.BaseDirectory;
        while (!string.IsNullOrEmpty(dir))
        {
            candidate = Path.Combine(dir, ".env");
            if (File.Exists(candidate))
            {
                return candidate;
            }

            candidate = Path.Combine(dir, "Lesson 6", ".env");
            if (File.Exists(candidate))
            {
                return candidate;
            }

            DirectoryInfo? parent = Directory.GetParent(dir);
            dir = parent?.FullName;
        }

        // 3. Traverse up from current directory
        dir = currentDir;
        while (!string.IsNullOrEmpty(dir))
        {
            candidate = Path.Combine(dir, ".env");
            if (File.Exists(candidate))
            {
                return candidate;
            }

            DirectoryInfo? parent = Directory.GetParent(dir);
            dir = parent?.FullName;
        }

        return null;
    }

    #endregion
}
