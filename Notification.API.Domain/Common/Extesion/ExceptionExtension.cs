﻿using Notification.API.Domain.Common.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Domain.Common.Extesion;
public static class ExceptionExtension
{
    public static async ValueTask<FuncResult<T>> GetValueAsync<T>(this Func<Task<T>> func) where T : struct
    {
        FuncResult<T> result;

        try
        {
            result = new FuncResult<T>(await func());
        }
        catch (Exception e)
        {
            result = new FuncResult<T>(e);
        }

        return result;
    }
    public static async ValueTask<FuncResult<T>> GetValueAsync<T>(this Func<ValueTask<T>> func) where T : struct
    {
        FuncResult<T> result;

        try
        {
            result = new FuncResult<T>(await func());
        }
        catch (Exception e)
        {
            result = new FuncResult<T>(e);
        }

        return result;
    }
}
