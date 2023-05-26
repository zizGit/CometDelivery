import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  isLogin: false,
  user: {},
};

const loginSlice = createSlice({
  name: "login",
  initialState,
  reducers: {
    setLogin(state, action) {
      state.isLogin = action.payload;
    },
  },
});

export const { setLogin } = loginSlice.actions;

export default loginSlice.reducer;
