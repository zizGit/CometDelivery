import React, { useState } from "react";
import styles from "./Registation.module.scss";

import { authUser } from "../../api/axios/core";
import { useDispatch } from "react-redux";
import { setLogin } from "../../redux/slices/loginSlice";

export default function Login({ setLoginForm, setVisiblePopUp }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const dispatch = useDispatch();
  const setUserAuth = (param) => {
    dispatch(setLogin(param));
  };
  const onChangePass = (event) => {
    setPassword(event.target.value);
    setError("");
  };
  const onChangeEmail = (event) => {
    setEmail(event.target.value);
    setError("");
  };
  const handleSubmit = (event) => {
    event.preventDefault();
    authUser({
      path: "login",
      password,
      email,
      setVisiblePopUp,
      setUserAuth,
      setError,
    });
  };

  return (
    <>
      <h2>Log in to Comet</h2>
      <p>
        New to Comet? <span onClick={() => setLoginForm(false)}>Sign up</span>
      </p>
      <button>Continue with Google</button>
      <button>Continue with Facebook</button>
      <div className={styles.row}>
        <hr />
        <p>or continue with email</p>
        <hr />
      </div>
      <form onSubmit={handleSubmit} className={styles.form}>
        <label htmlFor="email">
          Email
          <input
            required
            type="email"
            placeholder="Email"
            id="email"
            value={email}
            onChange={onChangeEmail}
          />
        </label>
        <label htmlFor="pass">
          Password
          <input
            required
            type="password"
            placeholder="Password"
            id="pass"
            value={password}
            onChange={onChangePass}
          />
        </label>{" "}
        {error && <p>{error}</p>}{" "}
        <button className={styles.submit}>Log in with email</button>
      </form>
    </>
  );
}
