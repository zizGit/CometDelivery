import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { setSection } from "../../redux/slices/categorySlice";

export default function Sections({ styles, categories = [] }) {
  const dispatch = useDispatch();
  // const { category } = useSelector((state) => state.categorySlice);
  const { section } = useSelector((state) => state.categorySlice);
  return (
    <div className={styles.categories}>
      <ul>
        {categories.map((item, id) => (
          <li
            key={id}
            onClick={() => dispatch(setSection({ name: item, id: id }))}
            className={item === section.name ? styles.active : ""}
          >
            {item}
          </li>
        ))}
      </ul>
    </div>
  );
}
