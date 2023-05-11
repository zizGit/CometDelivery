import { configureStore } from "@reduxjs/toolkit";
import cart from "./slices/cartSlice";
import categorySlice from "./slices/categorySlice";
export const store = configureStore({
  reducer: { cart, categorySlice },
});
