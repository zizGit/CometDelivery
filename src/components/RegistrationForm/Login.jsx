import React from "react";
import styles from "./Registation.module.scss";

export default function Login({ setLoginForm }) {
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
      <form action="#" className={styles.form}>
        <label htmlFor="email">
          Email
          <input type="email" placeholder="Email" id="email" />
        </label>
        <label htmlFor="password">
          Password
          <input type="password" placeholder="Password" id="password" />
        </label>
        <button className={styles.submit}>Log in with email</button>
      </form>
    </>
  );
}
