﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Runtime.CompilerServices;

namespace CallOfDuty
{
    public abstract class TimeProvider
    {
        private static TimeProvider current =
            DefaultTimeProvider.Instance;

        public static TimeProvider Current
        {
            get { return TimeProvider.current; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                TimeProvider.current = value;
            }
        }
       
        public abstract DateTime UtcNow { get; }
       
        public static void ResetToDefault()
        {
            TimeProvider.current = DefaultTimeProvider.Instance;
        }

        public class DefaultTimeProvider : TimeProvider
        {
            private readonly static DefaultTimeProvider instance =
                new DefaultTimeProvider();

            private DefaultTimeProvider() { }

            public override DateTime UtcNow
            {
                get { return DateTime.UtcNow; }
            }
        

            public static DefaultTimeProvider Instance
            {
                get { return DefaultTimeProvider.instance; }
            }
            

        }
    }
}
