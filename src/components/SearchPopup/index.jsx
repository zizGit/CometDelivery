import React, { useEffect, useState } from "react";
import { getRestorantsByName } from "../../api/axios/core";
import { Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { setRestorant } from "../../redux/slices/categorySlice";

export default function SearchPopUp({ styles, searchValue, setSearchValue }) {
  const [items, setItems] = useState([]);
  const [isLoading, setIsLoading] = useState(-1);
  const [isSelected, setIsSelected] = useState(false);
  const { isLogin } = useSelector((state) => state.loginSlice);
  const dispatch = useDispatch();
  console.log("items :>> ", items);
  useEffect(
    () => getRestorantsByName(searchValue, setItems, setIsLoading),
    [searchValue, isLoading]
  );

  return (
    <div>
      {items.length > 0 && (
        <div className={styles.popup}>
          {items.map((element, index) => (
            <Link
              to={`establishment/${element.name}`}
              key={element.id}
              onClick={() => {
                setIsSelected(index);
                dispatch(
                  setRestorant({
                    name: element.name,
                    imageUrl: element.imageUrl,
                    sections: element.sections,
                  })
                );
                setSearchValue("");
                if (!isLogin) {
                  alert("Login Please");
                }
              }}
              className={isSelected === index ? styles.selected : ""}
            >
              {element.name}
            </Link>
          ))}
        </div>
      )}
    </div>
  );
}
