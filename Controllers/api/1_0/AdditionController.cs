using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Mime;
using sample002.models;


namespace sample002.Controllers;

[ApiController]
[Route("api/1.0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AdditionController : ControllerBase
{
    private readonly ILogger<AdditionController> _logger;

    public AdditionController(ILogger<AdditionController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<RootOuput> Addition(RootInput ri)
    {
        code.Validations codeValidations = new code.Validations();
        RootOuput ro = new RootOuput();
        CalculationOutput co = new CalculationOutput();
        

        // Check 'addition' was requested, otherwise abort
        if (ri.calculationInput.inputs.requiredCalculation.ToLower() != "addition")
        {
            ErrorController ec = new ErrorController();
            return ec.JsonErrorResponse("addition","400","The requiredCalculation value submitted in the json payload does not equal 'addition'. Review the request json payload and API route used, to ensure they are compatible.");
        }


        //Ensure the supplied numeric values are consistent and correct in terms of culture and notation
        bool consistentSuppliedInputNumericValues = codeValidations.consistentNumericalValues(ri.calculationInput.inputs.numericValues);
        if (!consistentSuppliedInputNumericValues)
        {
            ErrorController ec = new ErrorController();
            return ec.JsonErrorResponse("addition","400","The supplied numeric values in the json payload were not consistent and correct in culture and notation. Review each of the request json payload' numericValues in terms of consistent numericInput, culture and notation.");
        }







        co.metadata =new Metadata();
        co.metadata.client = "AppSettings:name"; //TODO pull from appsettings.json
        co.metadata.version = "AppSettings:vesion"; //TODO pull from appsettings.json
        co.metadata.timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss.fffZ");



        co.receivedInputs = new ReceivedInputs();
        co.receivedInputs.numericValues = ri.calculationInput.inputs.numericValues;
        co.receivedInputs.requiredCalculation = ri.calculationInput.inputs.requiredCalculation;
        co.receivedInputs.requiredOutputFormatCulture = ri.calculationInput.inputs.requiredOutputFormatCulture;
        co.receivedInputs.requiredOutputFormatNotation = ri.calculationInput.inputs.requiredOutputFormatNotation;


        // Sum the supplied numeric values according to their values, culture and notation
        NumericCalculatedResults ncr = new NumericCalculatedResults();
        sample002.code.Calculations calculations = new code.Calculations();
        ncr = calculations.addNumericValues(co.receivedInputs.numericValues);

        List<NumericCalculatedResults> lncr = new List<NumericCalculatedResults>();
        



        //If requiredOutputFormatCulture and requiredOutputFormatNotation differ from input, supply the results in the required Output format
        if (ri.calculationInput.inputs.numericValues[0].culture.ToLower() != ri.calculationInput.inputs.requiredOutputFormatCulture.ToLower())
        {
            NumericCalculatedResults ncrOutputFormat = new NumericCalculatedResults();
            code.Conversions conversions = new code.Conversions();
            ncrOutputFormat = conversions.convertNumericCalculatedResult(ncr,ri.calculationInput.inputs.requiredOutputFormatCulture,ri.calculationInput.inputs.requiredOutputFormatNotation);
            lncr.Add(ncr);
            lncr.Add(ncrOutputFormat);
        }
        else
        {
            lncr.Add(ncr);
        }


        CalculatedOutputs cos = new CalculatedOutputs();

        cos.numericCalculatedResults = lncr;
        cos.responseCode = "200";
        cos.responseDescription = "OK";

        co.calculatedOutputs = cos;

        ro.calculationOutput = co;

        return new OkObjectResult(ro);
        
        
    }

    
}

