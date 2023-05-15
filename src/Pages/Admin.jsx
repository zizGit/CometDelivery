import React from "react";
import axios from "axios";
export default function Admin() {
  const request = () => {};
  return (
    <>
      <div onClick={request}>Admin</div>
      <h1 onClick={() => localStorage.removeItem("cometFoodLogin")}>
        314241241234124
      </h1>
    </>
  );
}
