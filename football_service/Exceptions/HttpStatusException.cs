﻿using System;
using System.Net;

namespace FootballService.Exceptions
{
    public class HttpStatusException: Exception
    {
        public HttpStatusCode Status { get; private set; }

        public HttpStatusException(HttpStatusCode status, string msg) : base(msg)
        {
            Status = status;
        }
    }
}
