﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data2.Statics
{
    public static class Conversion
    {
        public static bool convertSQLToBoolean(object p_MySQLBOOLEAN)
        {
            string result = p_MySQLBOOLEAN.ToString().ToLower();
            switch (result)
            {
                case "1":
                case "true": { return true; }
                case "0":
                case "false": { return false; }
                default: return false;
            }
        }

        public static Decimal GetDecimal(string mydecimal) 
        {

            //Log.ADD("Convirtiendo:" +  mydecimal, null);

            char myDecimalChar='.';
            if (Convert.ToDecimal("1,1") == 1.1m) myDecimalChar = ',';
            if (Convert.ToDecimal("1.1") == 1.1m) myDecimalChar = '.';

            string mydecimalconverted = mydecimal.Replace(',', myDecimalChar);
            mydecimalconverted = mydecimalconverted.Replace('.', myDecimalChar);

            try
            {

                return Convert.ToDecimal(mydecimalconverted);
            }
            catch 
            {
                return 0m;
            }


        }
    }
}
