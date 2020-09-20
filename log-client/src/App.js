import React, { useState, useEffect, useCallback } from "react";
import "./style.css";
import Header from "./LogComponents/Header";
import DropDown from "./LogComponents/DropDown";
import LogTable from "./LogComponents/LogTable";

const BaseApiUrl = process.env.REACT_APP_API_URL;
const SeverityOption = process.env.REACT_APP_API_URL_SEVERITY_OPTION;

function App() {
  const [viewLog, setViewLog] = useState([]);
  const [severityDropDown, setSeverityDropDown] = useState("");
  const [dropdownOptions, setDropdownOptions] = useState([]);

  const handleSelect = (event) => {
    setSeverityDropDown(event);
  };

  useEffect(() => {
    // Fetch dropdown options
    async function fetchingSeverityOptions() {
      const dropdownResp = await fetch(SeverityOption);
      const severityData = await dropdownResp.json();
      setDropdownOptions(severityData);
    }
    fetchingSeverityOptions();
  }, []);

  const getLogs = useCallback(async () => {
    const response = await fetch(BaseApiUrl + severityDropDown.toLowerCase());
    const data = await response.json();
    setViewLog(data);
  }, [severityDropDown]);

  useEffect(() => {
    getLogs();
    // eslint-disable-next-line no-use-before-define
  }, [getLogs]);

  return (
    <>
      <Header />
      <DropDown dropdownOptions={dropdownOptions} handleSelect={handleSelect} />
      <LogTable viewLog={viewLog} />
    </>
  );
}

export default App;
