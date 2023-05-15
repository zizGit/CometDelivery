import { useDispatch, useSelector } from "react-redux";
import { setCategory, setSection } from "../../redux/slices/categorySlice";
import { Link } from "react-router-dom";

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

  return (
    <div className={styles.categories}>
      <ul>
        {categories.map((item, id) => (
          <Link key={id} to="/establishment">
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
