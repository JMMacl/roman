import React, { InputHTMLAttributes } from "react";

interface Props extends InputHTMLAttributes<HTMLInputElement>{
  name: string;
  label?: string;
}

const Input: React.FC<Props> = ({ 
    name,
    label
  }) => { 
  return (
    <div className="Input-Component">
      <label htmlFor={name}>{label}</label>
      <input id={name}></input>
    </div>     
  );
}

export default Input;