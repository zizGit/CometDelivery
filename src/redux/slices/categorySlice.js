import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  category: { name: "Fast Food", id: 0 },
  restorant: { name: "", imageUrl: "", sections: [] },
  activeSection: { name: "", id: 0 },
};

const categorySlice = createSlice({
  name: "category",
  initialState,
  reducers: {
    setCategory(state, action) {
      state.category = action.payload;
    },
    // setSections(state, action) {
    //   state.restorant.sections = [...action.payload];
    //   state.activeSection = { name: action.payload[0], id: 0 };
    // },
    setRestorant(state, action) {
      state.restorant = action.payload;
      state.activeSection = { name: action.payload.sections[0], id: 0 };
    },
    setActiveSection(state, action) {
      state.activeSection = action.payload;
    },
  },
});

export const { setCategory, setSections, setRestorant, setActiveSection } =
  categorySlice.actions;

export default categorySlice.reducer;
