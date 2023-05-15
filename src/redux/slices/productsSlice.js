import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  products: [],
  error: [],
};

const productsSlice = createSlice({
  name: "products",
  initialState,
  reducers: {
    setProudcts(state, action) {
      state.products = [...action.payload];
    },
  },
});

export const { setProudcts } = productsSlice.actions;

export default productsSlice.reducer;
