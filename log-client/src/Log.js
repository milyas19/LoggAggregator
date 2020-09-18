import React from "react";

const Log = ({ id, severity, createdDate, hostName, message }) => {
  return (
    <>
      <div>{id}</div>
      <div>{createdDate}</div>
      <div>{hostName}</div>
      <div>{severity}</div>
      <div>{message}</div>
    </>
  );
};
export default Log;
