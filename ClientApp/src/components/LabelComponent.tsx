import React from 'react';

interface LabelProps {
  value: string;
  title?: string;
  children?: React.ReactNode;
}

const ResultLabel: React.FC<LabelProps> = ({ value, title, children}) => {
  return (
    <div className="Result-Component">
      <span title={title}>{value}</span>
      <div>{children}</div>
    </div>
  );
};

export default ResultLabel;