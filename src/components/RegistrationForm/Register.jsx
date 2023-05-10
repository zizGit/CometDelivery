import React from "react";
import styles from "./Registation.module.scss";
export default function Login({ setLoginForm }) {
  return (
    <>
      <h2>Sign up to Comet</h2>
      <p>
        Got an account already?{" "}
        <span onClick={() => setLoginForm(true)}>Log in</span>
      </p>
      <button>Sign Up with Google</button>
      <button>Sign Up with Facebook</button>
      <div className={styles.row}>
        <hr />
        <p>or continue with email</p>
        <hr />
      </div>
      <form action="#" className={styles.form}>
        <label htmlFor="first_name">
          First name
          <input type="first_name" placeholder="First name" id="first_name" />
        </label>
        <label htmlFor="email">
          Email
          <input type="email" placeholder="Email" id="email" />
        </label>
        <label htmlFor="password">
          Password
          <input type="password" placeholder="Password" id="password" />
        </label>
        <button className={styles.submit}>Sign up with email</button>
      </form>
    </>
  );
}
