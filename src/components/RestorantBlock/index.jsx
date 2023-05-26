import React from "react";
import styles from "./Restorant.module.scss";
import bikeSvg from "../../assets/RestorantPage/bike.svg";
import clockSvg from "../../assets/RestorantPage/clock.svg";
import { Link } from "react-router-dom";
import { useDispatch } from "react-redux";
import { setRestorant } from "../../redux/slices/categorySlice";

export default function RestorantBlock({
  name,
  imageUrl,
  types,
  deliveryCost,
  deliveryTime,
  sections,
}) {
  const dispatch = useDispatch();
  return (
    <div className={styles.container}>
      <div className={styles.container__top}>
        <Link to={`/establishment/${name}`}>
          <img src={imageUrl.replace(".png", "m.png")} alt="" />
          <div
            className={styles.container__about}
            onClick={() => dispatch(setRestorant({ name, imageUrl, sections }))}
          >
            <h3>{name}</h3>
            <div className={styles.container__categories}>
              {types.map((element, index) => (
                <p key={index}>{element}</p>
              ))}
            </div>
          </div>
        </Link>
      </div>
      <div className={styles.container__bottom}>
        <div className={styles.delivery}>
          <div className={styles.delivery__section}>
            <img src={bikeSvg} alt="bike" />
            <span>{deliveryCost}</span>uah
          </div>
          <div className={styles.delivery__section}>
            <img src={clockSvg} alt="bike" />
            <span>
              {deliveryTime[0]}-{deliveryTime[1]}
            </span>{" "}
            min
          </div>
        </div>
      </div>
    </div>
  );
}
