import React from "react";
import styles from "./Checkout.module.scss";
export default function Checkout() {
  return (
    <div className={styles.checkout}>
      <form className={styles.main__form}>
        <h3>One step Checkout</h3>
        <section>
          <label htmlFor="first_name">
            First Name
            <input type="text" id="first_name" />
          </label>
          <label htmlFor="phone_number">
            Phone number
            <input type="email" id="phone_number" />
          </label>
        </section>
        <section>
          <label htmlFor="city">
            City
            <input type="text" id="city" />
          </label>
          <label htmlFor="email">
            Email
            <input type="email" id="email" />
          </label>
        </section>

        <label htmlFor="adress">
          Adress
          <input type="text" id="adress" />
        </label>

        <div className={styles.payment}>
          <label htmlFor="card">
            <input type="radio" name="payment" id="card" />
            Payment by card on the site
          </label>
          <label htmlFor="cash">
            <input type="radio" name="payment" id="cash" />
            Cash
          </label>
        </div>

        <button type="submit">Checkout</button>
      </form>
    </div>
  );
}
