import React, { useEffect } from "react";

import styles from "./RestorantPage.module.scss";
import ProductBlock from "../../components/ProductBlock";
import ShoppingCart from "../../components/ShoppingCart";
import MainLogo from "../../assets/Establishment/image 13 (1).png";
import { Link, useParams } from "react-router-dom";
import Sections from "../../components/Sections";
import { useDispatch } from "react-redux";
import { setRestorant, setSection } from "../../redux/slices/categorySlice";

export default function RestorantPage({
  sections = [
    "Buckets",
    "Juicy chicken",
    "Burgers",
    "Sauces",
    "Desserts",
    "Cold drinks",
    "Hot drinks",
    "Beer",
    "Other",
  ],
}) {
  const arr = [...new Array(5)];
  let { title } = useParams();
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(setSection({ name: sections[0], id: 0 }));
    dispatch(setRestorant(title));
  });
  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);
  return (
    <div className={styles.wrapper}>
      <h2>
        <Link to="/establishment">All establishments /</Link>
        <span>{title}</span>
      </h2>
      <div className={styles.wrapper__logo}>
        <h3>{title}</h3>
        <img src={MainLogo} alt="" />
      </div>
      <div className={styles.content}>
        <div className={styles.content__categories}>
          <p>Sections</p>
          <Sections styles={styles} categories={sections} />
        </div>
        <div className={styles.content__products}>
          {arr.map((_, index) => (
            <ProductBlock key={index} name={"Bucket 26 wings"} price={200} />
          ))}
          {arr.map((_, index) => (
            <ProductBlock key={index} name={"Bucket 26 wings"} price={200} />
          ))}
        </div>
        <div className={styles.content__cart}>
          <ShoppingCart />
        </div>
      </div>
    </div>
  );
}
