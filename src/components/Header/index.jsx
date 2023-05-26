import React, { useState } from "react";
import styles from "./Header.module.scss";
import Logo from "../../assets/Header/Logo.svg";

import RegistrationForm from "../RegistrationForm";
import { Link } from "react-router-dom";
import Search from "./Search";

import CustomLink from "../CustomLink";
export default function Header() {
  const [isVisiblePopUp, setVisiblePopUp] = useState(false);

  return (
    <div className={styles.header}>
      {isVisiblePopUp && <RegistrationForm setVisiblePopUp={setVisiblePopUp} />}
      <Link to="/">
        <img className={styles.logo} src={Logo} alt="" />
      </Link>
      <Search />

      <CustomLink setVisiblePopUp={setVisiblePopUp} />
    </div>
  );
}
