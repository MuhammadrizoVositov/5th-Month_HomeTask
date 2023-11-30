using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.API.Domain.Common.Entitys;
public interface IEntity
{
    public Guid Id { get; set; }
}
