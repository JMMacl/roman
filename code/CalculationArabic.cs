using System;
using System.Collections.Specialized;
using System.Linq;

using sample002.models;

namespace sample002.code;

public class CalculationArabic
{

    public NumericCalculatedResults addArabicNumbers (List<NumericValue> numericValues)
    {
        //Note: Roman numerals are only expressed in decimal base10 notation, so we ignore the supplied notation value
        //Note: As per the brief *As we are in Rome there is no such thing as a decimal or int, we need to this working on strings.* Hence, we refrain from (the easier) converting all inputs to integers, adding them, and then converting the total back to a roman numeral
        NumericCalculatedResults ncr = new NumericCalculatedResults();

        //For each subsequent value, we will add it to the running total of values
        int runningTotal = 0;
        for (int i=0; i< numericValues.Count;i++)
        {
            runningTotal += Convert.ToInt32(numericValues[i].numericInput);
        }

        ncr.numericValues = numericValues;
        ncr.numericCalculatedResult = Convert.ToString(runningTotal);
        ncr.culture = "arabic";
        ncr.notation = "decimal";

        return ncr;

    }

}