﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using NuGet;

namespace PackageExplorer {
    public class PackageInfoLastUpdatedConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            var items = (IEnumerable<object>)value;
            return items.OfType<PackageInfo>().OrderByDescending(p => p.LastUpdated).Select(p => p.LastUpdated).FirstOrDefault();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}