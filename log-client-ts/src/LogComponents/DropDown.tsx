import React from "react";

interface IDropDown {
  dropdownOptions: any[];
  handleSelect: (event: any) => void;
  severityDropDown: string;
}

const DropDown: React.FC<IDropDown> = ({
  dropdownOptions,
  handleSelect,
  severityDropDown,
}) => {
  return (
    <label className="dropDownSeverity">
      Log Severity
      <select
        id="first"
        value={severityDropDown}
        onChange={(e) => handleSelect(e.target.value)}
      >
        <option value="">All</option>
        {dropdownOptions.map((severityData, i) => (
          <option key={i} value={severityData}>
            {" "}
            {severityData}{" "}
          </option>
        ))}
      </select>
    </label>
  );
};

export default DropDown;
