import axios from "axios";
import React, { useState } from "react";

export default function RestorantEdit({ restorant, setChange }) {
  const [editKey, setEditKey] = useState("");
  const [editValue, setEditValue] = useState("");
  const [reDraw, setreDraw] = useState(true);
  const keys = [];
  const display = () => {
    for (var i in restorant) {
      if (restorant.hasOwnProperty(i)) {
        keys.push(i);
      }
    }
  };
  const request = () => {
    axios
      .put(`http://localhost:5001/api/shops/${restorant.name}`, {
        ...restorant,
        [editKey]: editValue,
      })
      .then(function (response) {
        console.log("response :>> ", response);
      })
      .catch(function (error) {
        console.log(error.message);
      });
  };
  const changeValue = () => {
    if (typeof editValue === "string" && editValue.includes(",")) {
      setEditValue(editValue.split(","));
    }
    request();
    setChange();
    setreDraw(!reDraw);
  };

  return (
    <div>
      {display()}
      {keys.map((el, index) => (
        <div key={index}>
          <h2
            onClick={() => {
              setEditKey(el);
              setEditValue(restorant[el]);
            }}
          >
            {el}
          </h2>
          {Array.isArray(restorant[el]) ? (
            restorant[el].map((el, index) => <p key={index}>{el}</p>)
          ) : (
            <p>{restorant[el]}</p>
          )}
        </div>
      ))}
      <label htmlFor="change">
        {editKey}
        <input
          type="text"
          id="change"
          value={editValue}
          onChange={(event) => setEditValue(event.target.value)}
        />
      </label>

      <button onClick={() => changeValue()}>Change</button>
    </div>
  );
}
