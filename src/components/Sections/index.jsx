import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { setActiveSection } from "../../redux/slices/categorySlice";

export default function Sections({ styles }) {
  const dispatch = useDispatch();

  const { sections } = useSelector((state) => state.categorySlice.restorant);
  const { activeSection } = useSelector((state) => state.categorySlice);
  console.log("sections :>> ", sections[0]);

  return (
    <div className={styles.categories}>
      <ul>
        {sections.map((item, id) => (
          <li
            key={id}
            onClick={() => dispatch(setActiveSection({ name: item, id: id }))}
            className={item === activeSection.name ? styles.active : ""}
          >
            {item}
          </li>
        ))}
      </ul>
    </div>
  );
}
