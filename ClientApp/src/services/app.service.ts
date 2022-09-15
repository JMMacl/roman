export class AppService_1_0 {


    // public async addition(): Promise<any> {
    //     const response = await fetch('/api/users');
    //     return await response.json();
    // }

    public async addNumerals(numericValues: any, requiredOutputFormatCulture: string, requiredOutputFormatNotation: string ) {

        var requestBody;


        const response = await fetch(`/api/1.0/addition`, {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: requestBody
          })
        return await response.json();
    }

}