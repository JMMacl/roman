using sample002.models;

namespace sample002.code;

public class Calculations
{
    public NumericCalculatedResults addNumericValues (List<NumericValue> numericValues)
    {

        // Determine culture and notation 
        //TODO - simplifed version assumes all values have the same culture and notation as per the prior validation (later version may support addition across different cultures/notations)
        string culture = numericValues[0].culture;
        string notation = numericValues[0].notation;


        
        // Sum the supplied numeric values according to their values, culture and notation
        NumericCalculatedResults ncr = new NumericCalculatedResults();

        if (culture.ToLower()=="romannumerals")
        {
            CalculationRomanNumerals crn = new CalculationRomanNumerals();            
            ncr = crn.addRomanNumerals(numericValues);
        }

        if (culture.ToLower()=="arabic")
        {
            CalculationArabic ca = new CalculationArabic();            
            ncr = ca.addArabicNumbers(numericValues);
        }

        return ncr;
    }


}