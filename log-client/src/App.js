import React, { useState, useEffect } from "react";
import "./App.css";
import Log from "./Log";

function App() {
  var url = "http://localhost:55539/api/loggaggregator";

  const [viewLog, setViewLog] = useState([]);

  const getLogs = async () => {
    const response = await fetch(url);
    const data = await response.json();
    setViewLog(data);
  };

  useEffect(() => {
    getLogs();
  });

  return (
    <div className="App">
      {viewLog.map((data) => (
        <Log
          key={data.id}
          createdDate={data.createdDate}
          hostName={data.hostName}
          severity={data.severity}
          message={data.message}
        />
      ))}
    </div>
  );
}

export default App;
