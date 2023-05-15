import React, { useEffect, useState } from "react";
import styles from "./Registation.module.scss";
import { redirect } from "react-router-dom";
import { authUser } from "../../api/axios/core";

export default function Login({ setLoginForm }) {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (event) => {
    event.preventDefault();
    authUser(password, email);
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
            type="text"
            placeholder="Email"
            id="email"
            value={email}
            onChange={(event) => setEmail(event.target.value)}
          />
        </label>
        <label htmlFor="pass">
          Password
          <input
            type="text"
            placeholder="Password"
            id="pass"
            value={password}
            onChange={(event) => setPassword(event.target.value)}
          />
        </label>
        <button className={styles.submit}>Log in with email</button>
      </form>
    </>
  );
}
