import React, { useEffect, useState } from "react";
import axios from "axios";
import RestorantEdit from "../components/Admin/RestorantEdit";
import styles from "./Admin.module.scss";
export default function Admin() {
  const [restaurant, setRestorant] = useState([]);
  const [selected, setSelected] = useState({});
  const [change, setChange] = useState(true);
  const setChangeValues = (obj) => {
    // setChange(...change, obj);
    console.log("obj :>> ", obj);
  };
  const getRestorants = () => {
    axios
      .get(`http://localhost:5001/api/shops`)
      .then(function (response) {
        setRestorant(response.data);
      })
      .catch(function (error) {
        console.log(error.message);
      });
  };
  const setChangeValue = () => {
    setChange(!change);
  };
  useEffect(() => {
    setChangeValues(false);
    setSelected(selected);
    getRestorants();
  }, [selected, change]);

  return (
    <div className={styles.root}>
      <div>
        {restaurant.map((el, index) => (
          <p onClick={() => setSelected(el)} key={index}>
            {el.name}
          </p>
        ))}
      </div>
      <div>
        <RestorantEdit restorant={selected} setChange={setChangeValue} />
      </div>
    </div>
  );
}
