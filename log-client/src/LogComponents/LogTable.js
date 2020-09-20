import React from "react";
import moment from "moment";

function LogTable({ viewLog }) {
  return (
    <div className="LogBody">
      <table>
        <thead className="tableHeader">
          <tr>
            <th>Id</th>
            <th>Date</th>
            <th>Host Name</th>
            <th>Severity</th>
            <th>Message</th>
          </tr>
        </thead>
        <tbody>
          {viewLog?.length &&
            viewLog.map((data, i) => (
              <tr key={i}>
                <td>{data.id}</td>
                <td>{moment(data.createdDate).format("LLL")}</td>
                <td>{data.hostName}</td>
                <td>{data.severity}</td>
                <td>{data.message}</td>
              </tr>
            ))}
        </tbody>
      </table>
    </div>
  );
}
export default LogTable;
