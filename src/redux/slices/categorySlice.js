import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  category: { name: "Restorant", id: -1 },
  section: { name: "", id: -1 },
};

const categorySlice = createSlice({
  name: "category",
  initialState,
  reducers: {
    setCategory(state, action) {
      state.category = action.payload;
      console.log(state.category);
    },
    setSection(state, action) {
      state.section = action.payload;
      console.log(state.section);
    },
  },
});

export const { setCategory, setSection } = categorySlice.actions;

export default categorySlice.reducer;
