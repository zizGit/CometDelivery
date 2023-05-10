import React, { useState } from "react";
import styles from "./Registation.module.scss";
import Register from "./Register";
import Login from "./Login";

export default function RegistrationForm({ setVisiblePopUp }) {
  const [isLoginForm, setLoginForm] = useState(true);

  return (
    <div
      className={styles.popup}
      onClick={() => {
        setVisiblePopUp(false);
      }}
    >
      <div
        className={styles.popup__content}
        onClick={(e) => e.stopPropagation()}
      >
        <svg
          className={styles.popup__close}
          onClick={() => {
            setVisiblePopUp(false);
          }}
          viewBox="0 0 22 22"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            d="M2 20L11 11L20 20M20 2L10.9983 11L2 2"
            stroke="#2C3D78"
            strokeWidth="3"
            strokeLinecap="round"
            strokeLinejoin="round"
          />
        </svg>
        {isLoginForm ? (
          <Login setLoginForm={setLoginForm} />
        ) : (
          <Register setLoginForm={setLoginForm} />
        )}
      </div>
    </div>
  );
}
