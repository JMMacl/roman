namespace sample002.models;



    public class RootInput
    {
        public CalculationInput calculationInput { get; set; }
    }



    public class CalculationInput
    {
        public Metadata metadata { get; set; }
        public Inputs inputs { get; set; }
    }

    public class Metadata
    {
        public string client { get; set; }
        public string version { get; set; }
        public string timestamp { get; set; }
    }

    public class Inputs
    {
        public List<NumericValue> numericValues { get; set; }
        public string requiredCalculation { get; set; }
        public string requiredOutputFormatCulture { get; set; }
        public string requiredOutputFormatNotation { get; set; }
    }

    public class ReceivedInputs
    {
        public List<NumericValue> numericValues { get; set; }
        public string requiredCalculation { get; set; }
        public string requiredOutputFormatCulture { get; set; }
        public string requiredOutputFormatNotation { get; set; }
    }

    public class NumericValue
    {
        public string numericInput { get; set; }
        public string culture { get; set; }
        public string notation { get; set; }
    }


    
    
    



    
    
    
    public class RootOuput
    {
        public CalculationOutput calculationOutput { get; set; }
    }
    
    
    public class CalculationOutput
    {
        public Metadata metadata { get; set; }
        public ReceivedInputs receivedInputs { get; set; }
        public CalculatedOutputs calculatedOutputs { get; set; }
    }

    public class CalculatedOutputs
    {
        public List<NumericCalculatedResults> numericCalculatedResults { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
    }
    

    public class NumericCalculatedResults
    {
        public List<NumericValue> numericValues { get; set; }
        public string numericCalculatedResult { get; set; }
        public string culture { get; set; }
        public string notation { get; set; }
    }