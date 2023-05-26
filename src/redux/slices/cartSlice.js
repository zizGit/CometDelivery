import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  cart: [],
  totalPrice: 0,
};

const cartSlice = createSlice({
  name: "cart",
  initialState,
  reducers: {
    addToCart(state, action) {
      let checked = true;
      state.cart = state.cart.map((obj) => {
        if (obj.name === action.payload.name) {
          obj.count++;
          checked = false;
        }
        return obj;
      });
      if (checked) {
        state.cart = [...state.cart, { ...action.payload, count: 1 }];
      }
    },
    removeFromCart(state, action) {
      state.cart = state.cart.filter((obj) => obj.name !== action.payload.name);
    },
    decreaseFromCart(state, action) {
      state.cart = state.cart.map((obj, index) => {
        if (obj.name === action.payload.name) {
          obj.count--;
          if (obj.count < 1) {
            obj.count = 1;
          }
        }
        return obj;
      });
    },
    resetCart(state, action) {
      state.cart = [];
    },
  },
});

export const { addToCart, removeFromCart, decreaseFromCart, resetCart } =
  cartSlice.actions;

export default cartSlice.reducer;
