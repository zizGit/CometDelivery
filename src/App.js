import "./App.css";
import Header from "./components/Header";
import Footer from "./components/Footer";
import AppRoutes from "./Routes/Routes";
import { useEffect } from "react";
import { setLogin } from "./redux/slices/loginSlice";
import { useDispatch } from "react-redux";

function App() {
  const dispatch = useDispatch();
  useEffect(() => {
    if (localStorage.getItem("cometFoodLogin")) {
      dispatch(setLogin(true));
    }
  }, []);
  return (
    <div>
      <Header />
      <AppRoutes />
      <Footer />
    </div>
  );
}

export default App;
