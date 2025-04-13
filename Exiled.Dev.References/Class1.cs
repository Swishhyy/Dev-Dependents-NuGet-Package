using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Exiled.Dev.References
{
    /// <summary>
    /// Provides information about the Exiled references included in this package.
    /// </summary>
    public static class ExiledReferences
    {
        /// <summary>
        /// Gets the version of the Exiled API included in this package.
        /// </summary>
        /// <returns>The version string of Exiled API.</returns>
        public static string GetExiledVersion()
        {
            try
            {
                var assembly = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(a => a.GetName().Name == "PluginAPI");
                
                return assembly?.GetName().Version.ToString() ?? "Unknown";
            }
            catch
            {
                return "Unknown (Error getting version)";
            }
        }

        /// <summary>
        /// Checks if all required Exiled plugin development references are available.
        /// </summary>
        /// <returns>True if all core references are found, otherwise false.</returns>
        public static bool ValidateReferences()
        {
            var requiredAssemblies = new[]
            {
                "Assembly-CSharp-Publicized",
                "PluginAPI",
                "Mirror"
            };

            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Select(a => a.GetName().Name)
                .ToList();

            return requiredAssemblies.All(required => loadedAssemblies.Contains(required));
        }

        /// <summary>
        /// Lists all Exiled-related references that are currently loaded.
        /// </summary>
        /// <returns>A list of loaded assembly names relevant to Exiled development.</returns>
        public static List<string> ListLoadedReferences()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => IsExiledRelated(a.GetName().Name))
                .Select(a => $"{a.GetName().Name} v{a.GetName().Version}")
                .ToList();
        }

        private static bool IsExiledRelated(string assemblyName)
        {
            var exiledRelatedKeywords = new[]
            {
                "Exiled",
                "Plugin",
                "Assembly-CSharp",
                "Mirror",
                "Unity"
            };

            return exiledRelatedKeywords.Any(keyword => 
                assemblyName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
