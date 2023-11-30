using FluentValidation;
using Notification.API.Domain.Common.Entity;
using Notification.API.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Infrostructure.Common.Setting.Validator;
public class EmailTemplateValidator:AbstractValidator<EmailTempalate>
{
    public EmailTemplateValidator()
    {
        RuleFor(template => template.Content)
            .NotEmpty()
         
            .MinimumLength(10)
           
            .MaximumLength(256);
     

        RuleFor(template => template.Type)
            .Equal(NotificationType.Email);
     
    }
}
