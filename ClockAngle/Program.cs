namespace ClockAngle
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            int hourEntry;
            int minutesEntry;
            int secondsEntry;
            
            double fullCircleRotationAngle = 360;
            
            int secondHandTicsPerRevolution = 60;
            int minuteHandTicsPerRevolution = (int)Math.Pow(secondHandTicsPerRevolution, 2); //60 * 60
            int hourHandTicsPerRevolution = minuteHandTicsPerRevolution * 12; //43200
            int hourHandTicsPerHour = hourHandTicsPerRevolution / 12; //3600

            

            double hourHandDegreePerTic = Math.Round((fullCircleRotationAngle / hourHandTicsPerRevolution), 9);
            //     360 / 43200 = 0.008333333 angle per tic. 
            // note: rounding to four decimals at .0083 affects the angle precision by several degrees.

            
            double minuteHandDegreePerTic = fullCircleRotationAngle / minuteHandTicsPerRevolution;
            //     360 / 3600 = 0.1 degree per tic
            
            GetTimeEntry(out hourEntry, out minutesEntry, out secondsEntry);

            double hourHandDegreePosition = GetHourHandAngle(hourEntry, minutesEntry, secondsEntry, hourHandTicsPerHour, hourHandDegreePerTic);
            double minuteHandDegreePosition = GetMinuteHandAngle(minutesEntry, secondsEntry, minuteHandDegreePerTic);



            Console.WriteLine("hour hand degree position: " + hourHandDegreePosition);
            Console.WriteLine("minute hand degree position: " + minuteHandDegreePosition);
            Console.WriteLine("Angle: " + GetAngle(hourHandDegreePosition, minuteHandDegreePosition));

        }


        static void GetTimeEntry(out int hourEntry, out int minutesEntry, out int secondsEntry)
        {
            Console.Write("Enter current hour: ");
            hourEntry = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter current min: ");
            minutesEntry = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter current seconds: ");
            secondsEntry = Convert.ToInt32(Console.ReadLine());

        }
        private static double GetHourHandAngle(int hour, int minutes, int seconds, int hourHandTicsPerHour, double hourAngleMultiplier)
        {
            int hourTics = hour * hourHandTicsPerHour;
            int minuteTics = GetCurrentMinuteHandTics(minutes, seconds);
            int totalTics = hourTics + minuteTics + seconds;

            return totalTics * hourAngleMultiplier;
        }

        private static double GetMinuteHandAngle(int minutes, int seconds, double minuteAngleMultiplier)
        {
            int totalMinuteTics = GetCurrentMinuteHandTics(minutes, seconds);
            int totalTics = totalMinuteTics + seconds;

            return totalTics * minuteAngleMultiplier;
        }

        private static int GetCurrentMinuteHandTics(int minutes, int seconds)
        {
            int minuteTics = minutes * 60;

            return minuteTics;
        }

        private static double GetAngle(double hourPos, double minPos)
        {
            if (hourPos - minPos == 180)
                return 180.0;
            else if (hourPos - minPos < 180)
                return Math.Abs(hourPos - minPos);
            else
                return Math.Abs(360 - (hourPos - minPos));
        }
    }
}