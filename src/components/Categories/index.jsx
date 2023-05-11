import { useDispatch, useSelector } from "react-redux";
import { setCategory, setSection } from "../../redux/slices/categorySlice";

function Categories({
  styles,
  isSection,
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
  const { section } = useSelector((state) => state.categorySlice);
  return (
    <div className={styles.categories}>
      <ul>
        {categories.map((item, id) => (
          <li
            key={id}
            onClick={
              isSection
                ? () => dispatch(setSection({ name: item, id: id }))
                : () => dispatch(setCategory({ name: item, id: id }))
            }
            className={
              (item === section.name || item === category.name) && styles.active
            }
          >
            {item}
          </li>
        ))}
      </ul>
    </div>
  );
}
export default Categories;
