import React from "react";
import ShoppingCart from "../../components/ShoppingCart";
import Checkout from "../../components/Checkout";
import styles from "./OrderPage.module.scss";
export default function OrderPage() {
  return (
    <div className={styles.wrapper}>
      <Checkout />
      <ShoppingCart />
    </div>
  );
}
