import React, { useState } from "react";
import styles from "./Registation.module.scss";
import ReactInputMask from "react-input-mask";
import { authUser } from "../../api/axios/core";
import { useDispatch } from "react-redux";
import { setLogin } from "../../redux/slices/loginSlice";

export default function Login({ setLoginForm, setVisiblePopUp }) {
  const [phoneNumber, setPhoneNumber] = useState("");
  const [name, setName] = useState("");
  const [password, setPassword] = useState("");
  const [email, setEmail] = useState("");
  const [error, setError] = useState("");
  const dispatch = useDispatch();

  const setUserAuth = (param) => {
    dispatch(setLogin(param));
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    authUser({
      path: "registration",
      password,
      name,
      phoneNumber,
      email,
      setVisiblePopUp,
      setUserAuth,
      setError,
    });
  };
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
      <form onSubmit={handleSubmit} className={styles.form}>
        <label htmlFor="first_name">
          Name
          <input
            required
            type="text"
            placeholder="First name"
            id="first_name"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </label>
        <label htmlFor="phone">
          Phone Number
          <ReactInputMask
            required
            mask="+38-(999)-999-99-99"
            placeholder="+38-(066)-000-00-00"
            value={phoneNumber}
            alwaysShowMask={false}
            onChange={(e) =>
              setPhoneNumber(e.target.value.split(/\D+/).join(""))
            }
          />
        </label>
        <label htmlFor="email">
          Email
          <input
            required
            type="email"
            placeholder="Email"
            id="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </label>
        <label htmlFor="password">
          Password
          <input
            required
            type="password"
            placeholder="Password"
            id="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </label>

        {error && <p>{error}</p>}
        <button className={styles.submit}>Sign up with email</button>
      </form>
    </>
  );
}
