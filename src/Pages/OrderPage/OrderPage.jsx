import React, { useEffect, useState } from "react";
import ShoppingCart from "../../components/ShoppingCart";
import Checkout from "../../components/Checkout";
import styles from "./OrderPage.module.scss";
import { resetCart } from "../../redux/slices/cartSlice";
import { useDispatch } from "react-redux";
export default function OrderPage() {
  const [orderIsDone, setOrderIsDone] = useState(false);
  const dispatch = useDispatch();
  useEffect(() => {
    window.scrollTo(0, 0);
    setTimeout(() => {
      if (orderIsDone) {
        dispatch(resetCart());
        setOrderIsDone(false);
      }
    }, 2000);
  }, [orderIsDone, dispatch]);

  return (
    <div className={styles.wrapper}>
      {!orderIsDone ? (
        <>
          <Checkout setOrderIsDone={setOrderIsDone} />
          <ShoppingCart isOrder={true} />
        </>
      ) : (
        <h2 className={styles.thanks}>Thanks for order!</h2>
      )}
    </div>
  );
}
