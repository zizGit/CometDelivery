import React, { useEffect, useState } from "react";

import styles from "./RestorantPage.module.scss";
import ProductBlock from "../../components/ProductBlock";
import ShoppingCart from "../../components/ShoppingCart";

import { Link } from "react-router-dom";
import Sections from "../../components/Sections";
import { useSelector } from "react-redux";
import { getProducts } from "../../api/axios/core";
import Skeleton from "./Skeleton";
export default function RestorantPage() {
  const [items, setItems] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const { restorant } = useSelector((state) => state.categorySlice);
  const { activeSection } = useSelector((state) => state.categorySlice);
  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);

  useEffect(() => {
    setIsLoading(true);
    getProducts(restorant, activeSection, setItems, setIsLoading);
  }, [activeSection, restorant]);

  const skeleton = [...new Array(9)].map((_, index) => (
    <Skeleton key={index} />
  ));
  return (
    <div className={styles.wrapper}>
      <h2>
        <Link to="/establishment">All establishments /</Link>
        <span>{restorant.name}</span>
      </h2>
      <div className={styles.wrapper__logo}>
        <h3>{restorant.name}</h3>
        <img src={restorant.imageUrl} alt="" />
      </div>
      <div className={styles.content}>
        <div className={styles.content__categories}>
          <p>Sections</p>
          <Sections styles={styles} />
        </div>
        <div className={styles.content__products}>
          {isLoading
            ? skeleton
            : items.map((element, index) => (
                <ProductBlock
                  key={index}
                  name={element.name}
                  price={element.price}
                  imageUrl={element.imageUrl}
                  id={element.id}
                />
              ))}
          {items.length < 1 && !isLoading && <h2>Nothing found... :(</h2>}
        </div>
        <div className={styles.content__cart}>
          <ShoppingCart />
        </div>
      </div>
    </div>
  );
}
