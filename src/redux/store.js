import { configureStore } from "@reduxjs/toolkit";
import cart from "./slices/cartSlice";
import categorySlice from "./slices/categorySlice";
import loginSlice from "./slices/loginSlice";
import productsSlice from "./slices/productsSlice";
export const store = configureStore({
  reducer: { cart, categorySlice, loginSlice, productsSlice },
});
