using sample002.models;

namespace sample002.code;

public class Conversions
{

    public NumericCalculatedResults convertNumericCalculatedResult (NumericCalculatedResults ncr, string outputCulture, string outputNotation)
    {

        String ncrCulture = string.Empty;
        String ncrNotation = string.Empty;

        ncrCulture = ncr.culture;
        ncrNotation = ncr.notation;

        ncrCulture = "romanNumerals";
        ncrNotation = "decimal";

        NumericCalculatedResults outputNCR = new NumericCalculatedResults();

        try
        {
            Console.WriteLine ("2:" + ncr.numericCalculatedResult.ToString() + "|" +ncr.culture.ToString());
        }
        catch (Exception e){

            Console.WriteLine ("2e:" + e.Message.ToString());
            Console.WriteLine ("2e:" + e.StackTrace.ToString());
            Console.WriteLine ("2e:" + e.Source.ToString());

        }


        // Determine culture and notation 
        //TODO - simplifed version assumes all values have the same culture and notation as per the prior validation (later version may support addition across different cultures/notations)

        try
        {
            
            if (ncr.culture.ToLower()=="romannumerals" && outputCulture.ToLower() == "arabic")
            {

                List<NumericValue> outputNCRNumericValues = new List<NumericValue>();
                for (int i=0; i<ncr.numericValues.Count();i++)
                {
                    models.NumericValue nv = new NumericValue();
                    nv.culture = outputCulture;
                    nv.notation = outputNotation;
                    nv.numericInput = this.convertFromRomanNumeralToArabic(ncr.numericValues[i].numericInput);

                    outputNCRNumericValues.Add(nv); 
                    
                }

                int numericValueSum = 0;
                for (int i=0; i< outputNCRNumericValues.Count();i++)
                {
                    numericValueSum = numericValueSum + Convert.ToInt32(outputNCRNumericValues[i].numericInput);
                }

                outputNCR.numericValues = outputNCRNumericValues;
                outputNCR.numericCalculatedResult = Convert.ToString(numericValueSum);    
                outputNCR.culture = "arabic";
                outputNCR.notation = "decimal"; 
            }

            
            if (ncr.culture.ToLower()=="arabic" && outputCulture.ToLower() == "romannumerals")
            {

                List<NumericValue> outputNCRNumericValues = new List<NumericValue>();
                for (int i=0; i<ncr.numericValues.Count();i++)
                {

                    models.NumericValue nv = new NumericValue();
                    nv.culture = outputCulture;
                    nv.notation = outputNotation;
                    nv.numericInput = this.convertFromArabicToRomanNumeral(ncr.numericValues[i].numericInput);

                    outputNCRNumericValues.Add(nv); 
                    
                }




                outputNCR.numericValues = outputNCRNumericValues;

                code.CalculationRomanNumerals ccr = new CalculationRomanNumerals();
                NumericCalculatedResults ncc = new NumericCalculatedResults();
                ncc = ccr.addRomanNumerals(outputNCR.numericValues);


                outputNCR.numericCalculatedResult = ncc.numericCalculatedResult;    
                outputNCR.culture = "romanNumerals";
                outputNCR.notation = "decimal"; 
            }

        }
        catch (Exception e){

            Console.WriteLine ("3be:" + e.Message.ToString());
            Console.WriteLine ("3be:" + e.StackTrace.ToString());
            Console.WriteLine ("3be:" + e.Source.ToString());

        }





        return outputNCR;
    }

    public string convertFromRomanNumeralToArabic(string romanNumeral)
    {


        string arabicValue = string.Empty;
        string additiveNotationRomanNumeral = string.Empty;

        code.CalculationRomanNumerals ccr = new CalculationRomanNumerals();

        additiveNotationRomanNumeral = ccr.convertRomanNumeralToAdditiveNotation(romanNumeral);

        // Calculate total for each char instance
        int freqI = additiveNotationRomanNumeral.Count(f => (f == 'I'));
        int freqV = additiveNotationRomanNumeral.Count(f => (f == 'V'));
        int freqX = additiveNotationRomanNumeral.Count(f => (f == 'X'));
        int freqL = additiveNotationRomanNumeral.Count(f => (f == 'L'));
        int freqC = additiveNotationRomanNumeral.Count(f => (f == 'C'));
        int freqD = additiveNotationRomanNumeral.Count(f => (f == 'D'));
        int freqM = additiveNotationRomanNumeral.Count(f => (f == 'M'));

        //Calculate Arabic Value

        int arabicValueInt = 0;

        arabicValueInt = arabicValueInt + freqI + freqV*5 + freqX*10 + freqL*50 + freqC*100 + freqD*500 + freqM*1000;

        arabicValue = Convert.ToString(arabicValueInt);

        return arabicValue;
    }

    public string convertFromArabicToRomanNumeral(string arabicNumber)
    {
        char[] arabicNumberCharacters = arabicNumber.ToCharArray();

        string additiveRomanNumeral = string.Empty;

        for (int i = 0; i<arabicNumberCharacters.Count(); i++)
        {


            switch (arabicNumberCharacters.Count() - i) 
            {
            case 4:
                additiveRomanNumeral += string.Concat(Enumerable.Repeat("M", Convert.ToInt32(arabicNumberCharacters[i].ToString()))); 
                break;
            case 3:
                additiveRomanNumeral += string.Concat(Enumerable.Repeat("C", Convert.ToInt32(arabicNumberCharacters[i].ToString())));
                break;
            case 2:
                additiveRomanNumeral += string.Concat(Enumerable.Repeat("X", Convert.ToInt32(arabicNumberCharacters[i].ToString()))); 
                break;
            case 1:
                additiveRomanNumeral += string.Concat(Enumerable.Repeat("I", Convert.ToInt32(arabicNumberCharacters[i].ToString()))); 
                break;
            }

        }


        string subtractiveRomanNumeral = string.Empty;
        code.CalculationRomanNumerals ccr = new CalculationRomanNumerals();
        subtractiveRomanNumeral = ccr.convertRomanNumeralToSubtractiveNotation (additiveRomanNumeral);

        return subtractiveRomanNumeral;


    }



}