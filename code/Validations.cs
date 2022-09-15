using sample002.models;

namespace sample002.code;

public class Validations
{
    public bool consistentNumericalValues (List<NumericValue> numericValues)
    {

        // Validate all inputs are consistent in terms of culture and notation, otherwise abort.
        bool numericValuesConsistentCulture;
        bool numericValuesConsitentNotation;
        string consistentCulture = string.Empty;
        string consistentNotation = string.Empty;

        for (int i = 0; i< numericValues.Count; i++)
        {
            if (consistentCulture==string.Empty)
            {
                consistentCulture = numericValues[i].culture;
            }
            else if (consistentCulture==numericValues[i].culture && numericValues[i].culture.Length>0)
            {
                numericValuesConsistentCulture = true;
            }
            else
            {
                numericValuesConsistentCulture = false;
                return false;
            }

        }

        for (int i = 0; i< numericValues.Count; i++)
        {
            if (consistentNotation==string.Empty)
            {
                consistentNotation = numericValues[i].notation;
            }
            else if (consistentNotation==numericValues[i].notation && numericValues[i].notation.Length>0)
            {
                numericValuesConsistentCulture = true;
            }
            else
            {
                numericValuesConsitentNotation = false;
                return false;
            }

        }


        // Validate numericInputs based on supplied culture and notation
        if (consistentCulture.ToLower() == "romannumerals")
        {
            if (!validateRomanNumerals(numericValues))
            {
                return false;
            }
        }



        return true;
    }

    



    public bool validateRomanNumerals (List<NumericValue> numericValues)
    {
        bool isValidRomanNumerals = true;
        bool isValidRomanNumeral = true; 

        for (int i=0; i < numericValues.Count;i++)
        {

            if (isValidRomanNumerals==true)
            {
                isValidRomanNumeral = validateSingleRomanNumeral(numericValues[i].numericInput);
                if (isValidRomanNumeral==true)
                {
                    isValidRomanNumerals = true;
                }
                else
                {
                    isValidRomanNumerals = false;
                }
            }            

        }

        return isValidRomanNumerals;

    }

    public bool validateSingleRomanNumeral (string romanNumeral)
    {
        bool validRomanNumeral = true;

        //Initial validation checking individual characters are accepted roman numerals
        char[] numerals = romanNumeral.ToUpper().ToCharArray();

        for (int i=0; i<numerals.Count();i++)
        {
            if (validRomanNumeral==true)
            {
                switch (numerals[i]) 
                {
                case 'I':
                    validRomanNumeral=true;
                    break;
                case 'V':
                    validRomanNumeral=true;
                    break;
                case 'X':
                    validRomanNumeral=true;
                    break;
                case 'L':
                    validRomanNumeral=true;
                    break;
                case 'C':
                    validRomanNumeral=true;
                    break;
                case 'D':
                    validRomanNumeral=true;
                    break;
                case 'M':
                    validRomanNumeral=true;
                    break;

                default:
                    validRomanNumeral=false;
                    break;
                }
            }

        }

        //TODO - Extended validation to introduce more sophisticated logic to only allow accepted patterns e.g. for subtractive notation e.g. "XL" (40) is allowed but not "VL" ('45')

        return validRomanNumeral;
    }









}