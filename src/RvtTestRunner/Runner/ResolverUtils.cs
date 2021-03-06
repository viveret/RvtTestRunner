﻿// <copyright file="ResolverUtils.cs" company="StarkBIM Inc">
// Copyright (c) StarkBIM Inc. All rights reserved.
// </copyright>

namespace RvtTestRunner.Runner
{
    using System.IO;
    using JetBrains.Annotations;
    using Microsoft.Extensions.DependencyModel;

    internal static class ResolverUtils
    {
        internal static bool TryResolvePackagePath([NotNull] IFileSystem fileSystem, [NotNull] CompilationLibrary library, [NotNull] string basePath, [NotNull] out string packagePath)
        {
            var path = library.Path;
            if (string.IsNullOrEmpty(path))
            {
                path = Path.Combine(library.Name.ToUpperInvariant(), library.Version.ToUpperInvariant());
            }

            packagePath = Path.Combine(basePath, path);

            return fileSystem.Directory.Exists(packagePath);
        }

        internal static bool TryResolveAssemblyFile([NotNull] IFileSystem fileSystem, [NotNull] string basePath, [NotNull] string assemblyPath, [NotNull] out string fullName)
        {
            fullName = Path.Combine(basePath, assemblyPath);

            return fileSystem.File.Exists(fullName);
        }
    }
}