namespace Calculator
{
    public class Computing
    {
        public  string OddOrEven (int value)
        {
            return value % 2 == 0 ? "Even" : "Odd";
                 
        }
        public int CalculateAge(int BirthDate, int CurrentYear)
        {
            if (BirthDate < 1) 
                return 0;
            if (BirthDate==0|| CurrentYear == 0)
            throw new ArgumentException();
            return CurrentYear - BirthDate;
            
        }
        public bool IsPrime(int value)
        {
            if(value < 2)
                return false;
            for(int divistor=2;divistor<=Math.Sqrt(value);divistor++)
                if(value%divistor==0) 
                    return false;
            return true;

        }
    }
}
