import React from "react";
import styles from "./ShoppingCart.module.scss";
import CartItem from "./CartItem";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";

export default function ShoppingCart() {
  const { cart } = useSelector((state) => state.cart);
  console.log(cart);
  const totalPrice = cart.reduce(function (sum, elem) {
    return sum + elem.price * elem.count;
  }, 0);
  return (
    <div className={styles.cart}>
      <div className={styles.cart__top}>
        <h3>Your order</h3>
      </div>
      <div className={styles.cart__items}>
        {cart.map((obj, index) => (
          <CartItem
            key={index}
            name={obj.name}
            price={obj.price}
            count={obj.count}
          />
        ))}
      </div>
      <div className={styles.cart__bottom}>
        <Link to="/order">Order delivery{totalPrice}</Link>
      </div>
    </div>
  );
}
