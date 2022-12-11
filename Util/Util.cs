using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace INF_0996_Trabalho.Util
{
    public static class Util
    {
            public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dirInfo, params string[] extensions)
            {
                var allowedExtensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);

                return dirInfo.EnumerateFiles()
                            .Where(f => allowedExtensions.Contains(f.Extension));
            }
    }
}