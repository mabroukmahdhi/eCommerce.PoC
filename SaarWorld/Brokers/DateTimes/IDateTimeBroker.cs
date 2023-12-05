// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using System;

namespace SaarWorld.Brokers.DateTimes
{
    public interface IDateTimeBroker
    {
        DateTimeOffset GetCurrentDateTimeOffset();
        bool IsStillRecent(DateTimeOffset date, int maxMinutes);
        bool DueDateRiched(DateTimeOffset dueDate);
    }
}