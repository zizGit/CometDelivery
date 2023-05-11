import React from "react";
import Categories from "../components/Categories";
import styles from "./RestorantPage.module.scss";
import ProductBlock from "../components/ProductBlock";
import ShoppingCart from "../components/ShoppingCart";
import MainLogo from "../assets/Establishment/image 13 (1).png";
import { Link } from "react-router-dom";

export default function RestorantPage() {
  const arr = [...new Array(5)];
  console.log(arr);

  return (
    <div className={styles.wrapper}>
      <h2>
        <Link to="/establishment">All establishments /</Link>
        <span>KFC</span>
      </h2>
      <div className={styles.wrapper__logo}>
        <h3>KFC</h3>
        <img src={MainLogo} alt="" />
      </div>
      <div className={styles.content}>
        <div className={styles.content__categories}>
          <p>Sections</p>
          <Categories
            styles={styles}
            isSection={true}
            categories={[
              "Buckets",
              "Juicy chicken",
              "Burgers",
              "Sauces",
              "Desserts",
              "Cold drinks",
              "Hot drinks",
              "Beer",
              "Other",
            ]}
          />
        </div>
        <div className={styles.content__products}>
          {arr.map((_, index) => (
            <ProductBlock key={index} name={"Bucket 26 wings"} price={200} />
          ))}
          {arr.map((_, index) => (
            <ProductBlock key={index} name={"Bucket 28 wings"} price={100} />
          ))}
          <ProductBlock name={"Bucket 29 wings"} price={300} />
          <ProductBlock name={"Bucket 30 wings"} price={300} />
        </div>
        <div className={styles.content__cart}>
          <ShoppingCart />
        </div>
      </div>
    </div>
  );
}
