import React, { useState, useEffect, useCallback } from "react";
import moment from "moment";
import "./style.css";

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
      const dropdownResp = await fetch(
        "http://localhost:55539/api/loggaggregator/severity"
      );
      const severityData = await dropdownResp.json();
      setDropdownOptions(severityData);
    }
    fetchingSeverityOptions();
  }, []);

  const getLogs = useCallback(async () => {
    const response = await fetch(
      "http://localhost:55539/api/loggaggregator?severity=" +
        severityDropDown.toLowerCase()
    );
    const data = await response.json();
    setViewLog(data);
  }, [severityDropDown]);

  useEffect(() => {
    getLogs();
    // eslint-disable-next-line no-use-before-define
  }, [getLogs]);

  return (
    <>
      <label>
        Log Severity
        <select
          id="first"
          value={severityDropDown}
          onChange={(e) => handleSelect(e.target.value)}
        >
          <option value="">All</option>

          {dropdownOptions.map((severityData, i) => (
            <option value={severityData}> {severityData} </option>
          ))}
        </select>
      </label>

      <div class="LogBody">
        <h1>Log Aggregator</h1>
        <table>
          <tr class="tableHeader">
            <th>Id</th>
            <th>Date</th>
            <th>Host Name</th>
            <th>Severity</th>
            <th>Message</th>
          </tr>
          <tbody class="renderElement">
            {viewLog?.length &&
              viewLog.map((data, i) => (
                <tr key={i}>
                  <td> {data.id}</td>
                  <td> {moment(data.createdDate).format("LLL")}</td>
                  <td> {data.hostName}</td>
                  <td> {data.severity}</td>
                  <td> {data.message}</td>
                </tr>
              ))}
          </tbody>
        </table>
      </div>
    </>
  );
}

export default App;
