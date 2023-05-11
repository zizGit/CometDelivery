import React from "react";
import axios from "axios";
export default function Admin() {
  const request = () => {
    axios
      .post("https://localhost:7159/api/users/login", {})
      .then(function (response) {
        console.log(response.data);
      })
      .catch(function (error) {
        console.log(error);
      });
  };

  return <div onClick={request}>Admin</div>;
}
