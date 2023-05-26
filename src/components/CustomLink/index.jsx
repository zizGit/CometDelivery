import React from "react";
import { Link, useLocation } from "react-router-dom";
import Rocket from "../../assets/Header/Union.svg";
import { useSelector } from "react-redux";
import styles from "./CustomLink.module.scss";
export default function CustomLink({ setVisiblePopUp }) {
  const { pathname } = useLocation();
  const { isLogin } = useSelector((state) => state.loginSlice);
  let text = "";
  let to = "";

  if (pathname === "/partner") {
    text = "Are you a customer?";
    to = "/";
  } else if (pathname === "/") {
    text = "Get started";
    if (isLogin) {
      to = "/establishment";
    }
  } else {
    text = "Become a partner";
    to = "/partner";
  }
  return (
    <Link
      to={to}
      onClick={pathname === "/" && !isLogin && (() => setVisiblePopUp(true))}
      className={styles.custom}
    >
      {text} <img src={Rocket} alt="cometFood" />
    </Link>
  );
}
