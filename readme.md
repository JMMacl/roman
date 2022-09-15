#Roman Numerals Calculator 

A Roman Numerals calculator React SPA with .NET 6 API backend built into Docker Container at https://hub.docker.com/repository/docker/johnmmac/roman

# NOTE THIS IS A WORK-IN-PROGRESS REPOSITIORY
The code is not complete, primarily lacking the development of the SPA to interact with the backend APIs

## Example Use
### API - For adding Roman Numerals and returning arabic values
method: **Post**  
to: http://localhost:4000/api/1.0/addition  
payload:  
````  
{
    "calculationInput": {
        "metadata": {
            "client": "calc",
            "version": "1234",
            "timestamp": "2022-06-22 14:32:56Z"
        },
        "inputs": { 
            "numericValues": [
                {"numericInput": "CXXII", "culture": "romanNumerals", "notation": "decimal"},
                {"numericInput": "C", "culture": "romanNumerals", "notation": "decimal"},
                {"numericInput": "XLIV", "culture": "romanNumerals", "notation": "decimal"}
            ], 
            "requiredCalculation":"addition",
            "requiredOutputFormatCulture":"arabic",
            "requiredOutputFormatNotation":"decimal"          
        }
    }
}
````  
returning
````  
{
    "calculationOutput": {
        "metadata": {
            "client": "AppSettings:name",
            "version": "AppSettings:vesion",
            "timestamp": "2022-09-15 08:04:12.680Z"
        },
        "receivedInputs": {
            "numericValues": [
                {
                    "numericInput": "CXXII",
                    "culture": "romanNumerals",
                    "notation": "decimal"
                },
                {
                    "numericInput": "C",
                    "culture": "romanNumerals",
                    "notation": "decimal"
                },
                {
                    "numericInput": "XLIV",
                    "culture": "romanNumerals",
                    "notation": "decimal"
                }
            ],
            "requiredCalculation": "addition",
            "requiredOutputFormatCulture": "arabic",
            "requiredOutputFormatNotation": "decimal"
        },
        "calculatedOutputs": {
            "numericCalculatedResults": [
                {
                    "numericValues": [
                        {
                            "numericInput": "CXXII",
                            "culture": "romanNumerals",
                            "notation": "decimal"
                        },
                        {
                            "numericInput": "C",
                            "culture": "romanNumerals",
                            "notation": "decimal"
                        },
                        {
                            "numericInput": "XLIV",
                            "culture": "romanNumerals",
                            "notation": "decimal"
                        }
                    ],
                    "numericCalculatedResult": "CCLXVI",
                    "culture": "romanNumerals",
                    "notation": "decimal"
                },
                {
                    "numericValues": [
                        {
                            "numericInput": "122",
                            "culture": "arabic",
                            "notation": "decimal"
                        },
                        {
                            "numericInput": "100",
                            "culture": "arabic",
                            "notation": "decimal"
                        },
                        {
                            "numericInput": "44",
                            "culture": "arabic",
                            "notation": "decimal"
                        }
                    ],
                    "numericCalculatedResult": "266",
                    "culture": "arabic",
                    "notation": "decimal"
                }
            ],
            "responseCode": "200",
            "responseDescription": "OK"
        }
    }
}
````  

### API - For adding Arabic numbers and returning Roman Numeral values  
(just change culture values accordingly)
method: **Post**  
to: http://localhost:4000/api/1.0/addition  
payload:  
````  
{
    "calculationInput": {
        "metadata": {
            "client": "calc",
            "version": "1234",
            "timestamp": "2022-06-22 14:32:56Z"
        },
        "inputs": { 
            "numericValues": [
                {"numericInput": "122", "culture": "arabic", "notation": "decimal"},
                {"numericInput": "100", "culture": "arabic", "notation": "decimal"},
                {"numericInput": "44", "culture": "arabic", "notation": "decimal"}
            ], 
            "requiredCalculation":"addition",
            "requiredOutputFormatCulture":"romanNumerals",
            "requiredOutputFormatNotation":"decimal"          
        }
    }
}
````  
returning
````  
{
    "calculationOutput": {
        "metadata": {
            "client": "AppSettings:name",
            "version": "AppSettings:vesion",
            "timestamp": "2022-09-15 08:10:11.250Z"
        },
        "receivedInputs": {
            "numericValues": [
                {
                    "numericInput": "122",
                    "culture": "arabic",
                    "notation": "decimal"
                },
                {
                    "numericInput": "100",
                    "culture": "arabic",
                    "notation": "decimal"
                },
                {
                    "numericInput": "44",
                    "culture": "arabic",
                    "notation": "decimal"
                }
            ],
            "requiredCalculation": "addition",
            "requiredOutputFormatCulture": "romanNumerals",
            "requiredOutputFormatNotation": "decimal"
        },
        "calculatedOutputs": {
            "numericCalculatedResults": [
                {
                    "numericValues": [
                        {
                            "numericInput": "122",
                            "culture": "arabic",
                            "notation": "decimal"
                        },
                        {
                            "numericInput": "100",
                            "culture": "arabic",
                            "notation": "decimal"
                        },
                        {
                            "numericInput": "44",
                            "culture": "arabic",
                            "notation": "decimal"
                        }
                    ],
                    "numericCalculatedResult": "266",
                    "culture": "arabic",
                    "notation": "decimal"
                },
                {
                    "numericValues": [
                        {
                            "numericInput": "CXXII",
                            "culture": "romanNumerals",
                            "notation": "decimal"
                        },
                        {
                            "numericInput": "C",
                            "culture": "romanNumerals",
                            "notation": "decimal"
                        },
                        {
                            "numericInput": "XLIV",
                            "culture": "romanNumerals",
                            "notation": "decimal"
                        }
                    ],
                    "numericCalculatedResult": "CCLXVI",
                    "culture": "romanNumerals",
                    "notation": "decimal"
                }
            ],
            "responseCode": "200",
            "responseDescription": "OK"
        }
    }
}
````  
