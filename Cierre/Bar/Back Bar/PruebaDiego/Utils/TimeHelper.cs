using System;

namespace PruebaDiego.Utils
{
    public static class TimeHelper
    {
        public static DateTime ConvertirFecha(string fecha)
        {
            try
            {
                var datos = fecha.Split("/");
                int year = int.Parse(datos[2].Split()[0]);
                int month = int.Parse(datos[1]);
                int day = int.Parse(datos[0]);
                TimeZoneInfo zonaColombia = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime convertDate = new(year, month, day);

                DateTime fechaColombia = TimeZoneInfo.ConvertTime(convertDate, zonaColombia);

                return fechaColombia;
            }
            catch (Exception)
            {
                return new(1900, 1, 1);
            }
        }
    }
}