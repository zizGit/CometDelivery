import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  category: { name: "Fast Food", id: 0 },
  section: { name: "", id: -1 },
  retorant: "",
};

const categorySlice = createSlice({
  name: "category",
  initialState,
  reducers: {
    setCategory(state, action) {
      state.category = action.payload;
    },
    setSection(state, action) {
      state.section = action.payload;
    },
    setRestorant(state, action) {
      state.retorant = action.payload;
    },
  },
});

export const { setCategory, setSection, setRestorant } = categorySlice.actions;

export default categorySlice.reducer;
