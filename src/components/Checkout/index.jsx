import React, { useEffect, useState } from "react";
import styles from "./Checkout.module.scss";
import { useSelector } from "react-redux";
import { takeOrder } from "../../api/axios/core";
import ReactInputMask from "react-input-mask";
export default function Checkout({ setOrderIsDone }) {
  const [phone, setPhoneNumber] = useState("");
  const [name, setName] = useState("");
  const [adress, setAdress] = useState("");
  const [email, setEmail] = useState("");
  const [payment, setPayment] = useState("cash");
  const { cart } = useSelector((state) => state.cart);
  const handleSubmit = (event) => {
    event.preventDefault();

    takeOrder(
      {
        name,
        email,
        phone: +phone,
        adress,
        payment,
        products: cart.map((obj) => obj.id),
      },
      setOrderIsDone
    );
  };

  useEffect(() => {});
  return (
    <div className={styles.checkout}>
      <form className={styles.main__form} onSubmit={handleSubmit}>
        <h3>One step Checkout</h3>
        <section>
          <label htmlFor="name">
            First Name
            <input
              required
              type="text"
              id="name"
              value={name}
              onChange={(event) => setName(event.target.value)}
            />
          </label>
          <label htmlFor="number">
            Phone number
            <ReactInputMask
              required
              mask="+38-(999)-999-99-99"
              placeholder="+38-(066)-000-00-00"
              value={phone}
              alwaysShowMask={false}
              onChange={(e) =>
                setPhoneNumber(e.target.value.split(/\D+/).join(""))
              }
            />
          </label>
        </section>
        <section>
          <label htmlFor="city">
            City
            <input
              required
              type="text"
              id="city"
              value={"Kharkiv"}
              onChange={() => {
                alert("Working only in Kharkiv");
              }}
            />
          </label>
          <label htmlFor="email">
            Email
            <input
              required
              type="email"
              id="email"
              value={email}
              onChange={(event) => setEmail(event.target.value)}
            />
          </label>
        </section>
        <label htmlFor="adres">
          Adress
          <input
            required
            type="text"
            id="adres"
            value={adress}
            onChange={(event) => setAdress(event.target.value)}
          />
        </label>
        <div className={styles.payment}>
          <label htmlFor="card">
            <input
              required
              type="radio"
              name="payment"
              id="card"
              onChange={() => setPayment("card")}
            />
            Payment by card on the site
          </label>
          <label htmlFor="cash">
            <input
              checked
              required
              type="radio"
              name="payment"
              id="cash"
              onChange={() => setPayment("cash")}
            />
            Cash
          </label>
        </div>

        <button type="submit">Checkout</button>
      </form>
    </div>
  );
}
