import React, { useEffect } from "react";
import ShoppingCart from "../../components/ShoppingCart";
import Checkout from "../../components/Checkout";
import styles from "./OrderPage.module.scss";
export default function OrderPage() {
  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);
  return (
    <div className={styles.wrapper}>
      <Checkout />
      <ShoppingCart isOrder={true} />
    </div>
  );
}
