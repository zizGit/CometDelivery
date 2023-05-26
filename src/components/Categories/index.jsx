import { useDispatch, useSelector } from "react-redux";
import { setCategory } from "../../redux/slices/categorySlice";
import { Link } from "react-router-dom";
import { useEffect } from "react";

function Categories({
  styles,

  categories = [
    "Fast Food",
    "Pizza",
    "Burgers",
    "Asian",
    "Bakery",
    "French",
    "Dessert",
    "Sushi",
    "American",
  ],
}) {
  const dispatch = useDispatch();
  const { category } = useSelector((state) => state.categorySlice);
  const { isLogin } = useSelector((state) => state.loginSlice);
  useEffect(() => {}, [isLogin, category]);
  return (
    <div className={styles.categories}>
      <ul>
        {categories.map((item, id) => (
          <Link
            onClick={() => !isLogin && alert("Login please")}
            key={id}
            to={isLogin ? "/establishment" : "/"}
          >
            <li
              onClick={() => dispatch(setCategory({ name: item, id: id }))}
              className={item === category.name ? styles.active : ""}
            >
              {item}
            </li>
          </Link>
        ))}
      </ul>
    </div>
  );
}
export default Categories;
