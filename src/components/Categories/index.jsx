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
  return (
    <div className={styles.categories}>
      <ul>
        {categories.map((item, id) => (
          <li
            key={id}
            // onClick={() => onChangeCategory(id)}
          >
            {item}
          </li>
        ))}
      </ul>
    </div>
  );
}
export default Categories;
