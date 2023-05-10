import React from "react";
import styles from "./Footer.module.scss";

export default function Footer() {
  return (
    <footer className={styles.footer}>
      <div className={styles.logo}></div>
      <div className={styles.footer__block}>
        <h2>Let's do it together</h2>
        <p>Comet for partner</p>
        <p>Couriers</p>
      </div>
      <div className={styles.footer__block}>
        <h2>Links of interest</h2>
        <p>About us</p>
        <p>FAQ</p>
        <p>Contact us</p>
        <p>Security</p>
      </div>
      <div className={styles.footer__block}>
        <h2>Follow us</h2>
        <p>Facebook</p>
        <p>Twitter</p>
        <p>Instagram</p>
      </div>
    </footer>
  );
}
