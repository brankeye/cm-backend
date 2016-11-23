﻿using System;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Enums;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;

namespace cm.backend.infrastructure.Api.Controllers
{
    public class ClassesController : CoreController<Data.Class>
    {
        public override Response Post(Data.Class item)
        {
            var startTime = item.StartTime;
            var endTime = item.EndTime;
            item.StartTime = new DateTime(1, 1, 1, startTime.Hour, startTime.Minute, startTime.Second, DateTimeKind.Utc);
            item.EndTime = new DateTime(1, 1, 1, endTime.Hour, endTime.Minute, endTime.Second, DateTimeKind.Utc);

            var day = item.Day;
            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" ||
                day == "Friday" || day == "Saturday" || day == "Sunday")
            {
                return base.Post(item);
            }

            return new Response
            { 
                Item = null,
                Message = "Day of class is invalid.",
                ResultCode = ResultCode.InsertFailed
            };
        }
    }
}