using System;
using System.Collections.Specialized;
using System.Linq;

using sample002.models;

namespace sample002.code;

public class CalculationRomanNumerals
{

    public NumericCalculatedResults addRomanNumerals (List<NumericValue> numericValues)
    {
        //Note: Roman numerals are only expressed in decimal base10 notation, so we ignore the supplied notation value
        //Note: As per the brief *As we are in Rome there is no such thing as a decimal or int, we need to this working on strings.* Hence, we refrain from (the easier) converting all inputs to integers, adding them, and then converting the total back to a roman numeral
        NumericCalculatedResults ncr = new NumericCalculatedResults();

        //For each subsequent value, we will add it to the running total of values
        string runningTotal = "";
        for (int i=0; i< numericValues.Count;i++)
        {
            if(i==0)
            {
                runningTotal = numericValues[i].numericInput;
            }
            else
            {
                runningTotal = addTwoRomanNumerals(runningTotal,numericValues[i].numericInput);
            }
        }

        ncr.numericValues = numericValues;
        ncr.numericCalculatedResult = runningTotal;
        ncr.culture = "romanNumerals";
        ncr.notation = "decimal";

        return ncr;

    }

    public string addTwoRomanNumerals (string romanNumeralOne, string romanNumeralTwo)
    {
        string romanNumeralSum = string.Empty;

        // Given the Roman numerals, (I,V,X,L,C,D,M)

        // Steps starting with the input:
        // romanNumeralOne & romanNumeralTwo

        // Convert any subtractive notation to additive notation to get:
        // DCCXXVI + XXXXVIII
        // then ombine the two numerals into one to get:
        // DCCXXVIXXXXVIII
        romanNumeralSum = this.convertRomanNumeralToAdditiveNotation(romanNumeralOne) + this.convertRomanNumeralToAdditiveNotation(romanNumeralTwo);


        // Sort the symbols highest to lowest to get:
        // DCCXXXXXXVVIIII
        romanNumeralSum = this.sortRomanNumeralCharacters(romanNumeralSum);

        // Simplify by replacing symbols, from right to left:
        // Replace “VV” with “X” to get
        // DCCXXXXXXXIIII
        // Replace “XXXXX” with “L” to get
        // DCCLXXIIII
        romanNumeralSum = this.simplifyRomanNumeral(romanNumeralSum);


        // Convert any additive notation back to subtractive notation to get:
        // DCCLXXIV
        romanNumeralSum = this.convertRomanNumeralToSubtractiveNotation(romanNumeralSum);

        // Answer:
        // DCCLXXIV
        return romanNumeralSum;
    }

         
    public string convertRomanNumeralToAdditiveNotation (string inputRomanNumeral)
    {
        string romanNumeral = inputRomanNumeral.ToUpper();

        //Replace subtractive notation instance with equivalent additive notation
        romanNumeral = romanNumeral.Replace("IV","IIII");
        romanNumeral = romanNumeral.Replace("IX","VIIII");
        romanNumeral = romanNumeral.Replace("XL","XXXX");
        romanNumeral = romanNumeral.Replace("XC","LXXXX");
        romanNumeral = romanNumeral.Replace("CD","CCCC");
        romanNumeral = romanNumeral.Replace("CM","DCCCC");

        return romanNumeral;
    }

    public string sortRomanNumeralCharacters (string inputRomanNumeral)
    {
        string romanNumeral = inputRomanNumeral.ToUpper();

        // Calculate total for each char instance
        int freqI = romanNumeral.Count(f => (f == 'I'));
        int freqV = romanNumeral.Count(f => (f == 'V'));
        int freqX = romanNumeral.Count(f => (f == 'X'));
        int freqL = romanNumeral.Count(f => (f == 'L'));
        int freqC = romanNumeral.Count(f => (f == 'C'));
        int freqD = romanNumeral.Count(f => (f == 'D'));
        int freqM = romanNumeral.Count(f => (f == 'M'));

        string outputRomanNumeral = string.Empty;

        // Use totals to create the output
        for (int i=0; i<freqM;i++){outputRomanNumeral+="M";}
        for (int i=0; i<freqD;i++){outputRomanNumeral+="D";}
        for (int i=0; i<freqC;i++){outputRomanNumeral+="C";}
        for (int i=0; i<freqL;i++){outputRomanNumeral+="L";}
        for (int i=0; i<freqX;i++){outputRomanNumeral+="X";}
        for (int i=0; i<freqV;i++){outputRomanNumeral+="V";}
        for (int i=0; i<freqI;i++){outputRomanNumeral+="I";}

        return outputRomanNumeral;
    }

    public string simplifyRomanNumeral (string inputRomanNumeral)
    {
        string romanNumeral = inputRomanNumeral.ToUpper();

        //Replace subtractive notation instance with equivalent additive notation

        romanNumeral = romanNumeral.Replace("IIIII","V");
        romanNumeral = romanNumeral.Replace("VV","X");
        romanNumeral = romanNumeral.Replace("XXXXX","L");
        romanNumeral = romanNumeral.Replace("LL","C");
        romanNumeral = romanNumeral.Replace("CCCCC","D");
        romanNumeral = romanNumeral.Replace("DD","M");

        return romanNumeral;
    }

    public string convertRomanNumeralToSubtractiveNotation (string inputRomanNumeral)
    {
        string romanNumeral = inputRomanNumeral.ToUpper();

        //Replace subtractive notation instance with equivalent additive notation
        romanNumeral = romanNumeral.Replace("IIII","IV");
        romanNumeral = romanNumeral.Replace("VIIII","IX");
        romanNumeral = romanNumeral.Replace("XXXX","XL");
        romanNumeral = romanNumeral.Replace("LXXXX","XC");
        romanNumeral = romanNumeral.Replace("CCCC","CD");
        romanNumeral = romanNumeral.Replace("DCCCC","CM");

        return romanNumeral;
    }

}