using MediatR;

namespace Clean_Arch.Domain.Shared
{
    public class BaseDoaminEvent:INotification
    {
        public DateTime CreationTime { get;  }
        public BaseDoaminEvent()
        {
            CreationTime = DateTime.Now;
        }
    }
}
