namespace Clean_Arch.Contracts
{


    public interface ISmsService
    {
        void SendSms(SmsBody smsBody);
    }
    public class SmsBody
    {
        //public SmsBody(string phoneNumber, string message)
        //{
        //    PhoneNumber = phoneNumber;
        //    Message = message;
        //}

        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
