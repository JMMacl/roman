// import React from 'react';
import React, { useReducer, ChangeEvent, Children } from 'react';
import logo from './logo.svg';
import './App.css';

import { AppService_1_0 } from './services/app.service';


import Button from "./components/ButtonComponent";
import Input from "./components/InputFieldComponent";
import ResultLabel from "./components/LabelComponent";

function App() {


  const appService = new AppService_1_0();

  const getResponse = async () => {
    const response = await appService.addNumerals("a","b","c");
    console.log("Result is:" +  response);
  }


  return (
    <div className="App">
      <h1>Roman Numerals Calculator</h1>
      <div className="Calculator-App-UI">
        <div className="Equation-Row">
        
        <Button 
            border="2px"
            color="#ccccff"
            onClick={() => console.log("You clicked on the light purple 'Add' square!" + getResponse.arguments.toString())}
            radius = "5%"
            width = "100px"
            height = "40px"
            children = "Add"
          />
          <span>&nbsp;&nbsp;</span>
          <Input
            name="InputOne"
          />
          <span>&nbsp;<b>+</b>&nbsp;</span>
          <Input
            name="InputTwo"
          />
          <span>&nbsp;<b>=</b>&nbsp;</span>
          <ResultLabel
            value="Result"
            title="Result"
            children=""
          />
        </div>
      </div>
      <div className="App-footer">
        <img src={logo} className="App-logo" alt="logo" width="50px"/>
        <p>
          Made with 🤔 using Typescript React &amp;amp; .NET 6, running on <img src="https://www.docker.com/wp-content/uploads/2022/01/Docker-Logo-White-RGB_Horizontal-730x189-1.png.webp" alt="docker" width="60px"/>.
        </p>        
      </div>
    </div>
  );
}

export default App;
