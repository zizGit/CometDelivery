import React from "react";
import styles from "./ProductBlock.module.scss";
import Food from "../../assets/FoodBlock/image 15.png";

import { useDispatch, useSelector } from "react-redux";
import { addToCart } from "../../redux/slices/cartSlice";

export default function ProductBlock({ name, price }) {
  const dispatch = useDispatch();

  return (
    <div className={styles.productblock}>
      <div className={styles.productblock__top}>
        <img src={Food} alt="" />
        <h3>{name}</h3>
      </div>
      <p>
        {price} uan
        <span onClick={() => dispatch(addToCart({ name, price }))}>
          <svg
            width="10"
            height="10"
            viewBox="0 0 10 10"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              d="M9.28571 5.71429H5.71429V9.28571C5.71429 9.47515 5.63903 9.65684 5.50508 9.79079C5.37112 9.92475 5.18944 10 5 10C4.81056 10 4.62888 9.92475 4.49492 9.79079C4.36097 9.65684 4.28571 9.47515 4.28571 9.28571V5.71429H0.714286C0.524845 5.71429 0.343164 5.63903 0.20921 5.50508C0.075255 5.37112 0 5.18944 0 5C0 4.81056 0.075255 4.62888 0.20921 4.49492C0.343164 4.36097 0.524845 4.28571 0.714286 4.28571H4.28571V0.714286C4.28571 0.524845 4.36097 0.343164 4.49492 0.209209C4.62888 0.0752547 4.81056 0 5 0C5.18944 0 5.37112 0.0752547 5.50508 0.209209C5.63903 0.343164 5.71429 0.524845 5.71429 0.714286V4.28571H9.28571C9.47515 4.28571 9.65684 4.36097 9.79079 4.49492C9.92475 4.62888 10 4.81056 10 5C10 5.18944 9.92475 5.37112 9.79079 5.50508C9.65684 5.63903 9.47515 5.71429 9.28571 5.71429Z"
              fill="#040B20"
            />
          </svg>
        </span>
      </p>
    </div>
  );
}
