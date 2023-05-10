import React from "react";
import styles from "./MainPageBlock.module.scss";
import Categories from "../Categories";
import Delivery from "../../assets/MainPage/Delivery.gif";
import Content1 from "../../assets/MainPage/Content/Content1.svg";
import Content2 from "../../assets/MainPage/Content/Content2.svg";
import Content3 from "../../assets/MainPage/Content/Content3.svg";
import Chief from "../../assets/MainPage/BecomePartner/Chief.png";
import { Link } from "react-router-dom";
export default function MainPageBlock() {
  return (
    <main className={styles.main}>
      <h2>Choose from popular categories</h2>
      <Categories styles={styles} />
      <section className={styles.main__section}>
        <img src={Delivery} alt="Delivery" />
        <h2>We deliver food wherever you are!</h2>
      </section>
      <section className={styles.main__content}>
        <h2>We will deliver anything!</h2>
        <div className={styles.wrapper}>
          <div className={styles.wrapper__contentblock}>
            <img src={Content1} alt="123" />
            <div className={styles.wrapper__text}>
              <h3>Order Online</h3>
              <p>
                We provide you with a huge selection of restaurants. Order your
                favorite food with us!
              </p>
            </div>
          </div>
          <div className={styles.wrapper__contentblock}>
            <img src={Content2} alt="123" />
            <div className={styles.wrapper__text}>
              <h3>Order picking</h3>
              <p>
                The restaurant takes orders directly and prepares delicious
                dishes in a short period of time
              </p>
            </div>
          </div>
          <div className={styles.wrapper__contentblock}>
            <img src={Content3} alt="123" />
            <div className={styles.wrapper__text}>
              <h3>ORDER DELIVERY</h3>
              <p>
                The advantage of our delivery is speed. We guarantee quality
                delivery in minutes
              </p>
            </div>
          </div>
        </div>
      </section>
      <section className={styles.partner}>
        <div className={styles.partner__text}>
          <h3>
            If you want to become our partner, please fill out the form and join
            our team!
          </h3>
          <p>
            Increase your sales and revenue by leveraging our expert knowledge
            and technology to manage your online business. Get started on your
            company's digital transformation process today.
          </p>
          <Link to="/partner">Become a partner</Link>
        </div>
        <img src={Chief} alt="Chief" />
      </section>
    </main>
  );
}
