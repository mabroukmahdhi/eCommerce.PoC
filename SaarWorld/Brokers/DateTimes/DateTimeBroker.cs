// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;

namespace SaarWorld.Brokers.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetCurrentDateTimeOffset() =>
            DateTimeOffset.UtcNow;

        public bool IsStillRecent(DateTimeOffset date, int maxMinutes)
        {
            DateTimeOffset currentDateTime =
                GetCurrentDateTimeOffset();

            TimeSpan timeDifference = currentDateTime.Subtract(
                date.ToUniversalTime());

            TimeSpan maxMinutesSpan = TimeSpan.FromMinutes(maxMinutes);

            return timeDifference.Duration() <= maxMinutesSpan;
        }

        public bool DueDateRiched(DateTimeOffset dueDate)
        {
            DateTimeOffset currentDateTime =
                GetCurrentDateTimeOffset();

            return currentDateTime >= dueDate;
        }
    }
}