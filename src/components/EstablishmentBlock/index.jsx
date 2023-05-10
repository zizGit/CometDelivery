import React from "react";
import styles from "./EstablishmentBlock.module.scss";
import Categories from "../Categories";

import RestorantBlock from "../RestorantBlock";
export default function EstablishmentBlock() {
  return (
    <div className={styles.wrapper}>
      <div className={styles.categories}>
        <p>Popular categories</p>
        <Categories styles={styles} />
      </div>
      <div className={styles.establishment}>
        <h2>All Establishment</h2>
        <div className={styles.establishment__restorants}>
          <RestorantBlock />
          <RestorantBlock />
          <RestorantBlock />
          <RestorantBlock />
          <RestorantBlock />
        </div>
      </div>
    </div>
  );
}
