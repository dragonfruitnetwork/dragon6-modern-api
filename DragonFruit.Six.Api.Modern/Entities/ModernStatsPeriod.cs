﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DragonFruit.Six.Api.Modern.Entities
{
    public class ModernStatsPeriod<T>
    {
        private readonly string _dateRange;

        private DateTime? _start, _end;
        private IEnumerable<string> _periods;

        public ModernStatsPeriod(string dateRange, T value)
        {
            _dateRange = dateRange;
            Value = value;
        }

        public T Value { get; set; }

        public DateTime Start => _start ??= ParsePeriodDate(Periods.First());

        public DateTime End => _end ??= ParsePeriodDate(Periods.Last());

        private IEnumerable<string> Periods => _periods ??= _dateRange.Split(':');

        private static DateTime ParsePeriodDate(string date) => DateTime.ParseExact(date, "yyyy-MM-dd", null, DateTimeStyles.AssumeUniversal);
    }
}
