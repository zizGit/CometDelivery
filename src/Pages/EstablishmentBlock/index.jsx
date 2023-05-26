import React, { useEffect, useState } from "react";
import styles from "./EstablishmentBlock.module.scss";
import Categories from "../../components/Categories";

import RestorantBlock from "../../components/RestorantBlock";
import Skeleton from "../../components/RestorantBlock/Skeleton";
import { useSelector } from "react-redux";
import { getRestorants } from "../../api/axios/core";
export default function EstablishmentBlock() {
  const { category } = useSelector((state) => state.categorySlice);
  const [isLoading, setIsLoading] = useState(true);
  const [items, setItems] = useState([]);

  useEffect(() => {
    setIsLoading(true);
    getRestorants(setItems, setIsLoading, category.name);
  }, [category]);

  const restorants = items.map((obj) => (
    <RestorantBlock
      key={obj.id}
      name={obj.name}
      imageUrl={obj.imageUrl}
      types={obj.types}
      deliveryCost={obj.deliveryCost}
      deliveryTime={obj.deliveryTime}
      sections={obj.sections}
    />
  ));
  const skeleton = [...new Array(6)].map((_, index) => (
    <Skeleton key={index} />
  ));

  return (
    <div className={styles.wrapper}>
      <div className={styles.categories}>
        <p>Popular categories</p>
        <Categories styles={styles} />
      </div>
      <div className={styles.establishment}>
        <h2>{category.name}</h2>
        <div className={styles.establishment__restorants}>
          {isLoading ? skeleton : restorants}
          {restorants.length < 1 && <h2>Noting found... :(</h2>}
        </div>
      </div>
    </div>
  );
}
