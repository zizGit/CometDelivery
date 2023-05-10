import React, { useState } from "react";
import styles from "./Header.module.scss";
import Logo from "../../assets/Header/Logo.svg";
import Rocket from "../../assets/Header/Union.svg";
import RegistrationForm from "../RegistrationForm";
import { Link } from "react-router-dom";
import Search from "./Search";

export default function Header() {
  const [isVisiblePopUp, setVisiblePopUp] = useState(false);
  return (
    <div className={styles.header}>
      {isVisiblePopUp && <RegistrationForm setVisiblePopUp={setVisiblePopUp} />}
      <Link to="/">
        <img className={styles.logo} src={Logo} alt="" />
      </Link>
      <Search />
      <button onClick={() => setVisiblePopUp(true)}>
        Get Started
        <img src={Rocket} alt="cometFood" />
      </button>
      <Link to="/establishment">41241</Link>
    </div>
  );
}
