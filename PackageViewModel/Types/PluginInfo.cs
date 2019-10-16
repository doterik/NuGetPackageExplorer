﻿using System;
using NuGet.Versioning;

namespace NuGetPackageExplorer.Types
{
    public class PluginInfo : IEquatable<PluginInfo>
    {
        public PluginInfo(string id, NuGetVersion version)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id cannot be null or empty.", nameof(id));
            }

            Id = id;
            Version = version ?? throw new ArgumentNullException(nameof(version));
        }

        public string Id { get; private set; }
        public NuGetVersion Version { get; private set; }

        #region IEquatable<PluginInfo> Members

        public bool Equals(PluginInfo other)
        {
            if (other is null) return false;

            return Id.Equals(other.Id, StringComparison.OrdinalIgnoreCase) && Version == other.Version;
        }

        #endregion

        public override string ToString()
        {
            return Id + " [" + Version + "]";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Version);
        }
    }
}
