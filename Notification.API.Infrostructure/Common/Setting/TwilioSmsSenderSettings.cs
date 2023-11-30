﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Infrostructure.Common.Setting;
public class TwilioSmsSenderSettings
{
    public string AccountSid { get; set; } = default!;

    public string AuthToken { get; set; } = default!;

    public string SenderPhoneNumber { get; set; } = default!;
}
