import "./App.css";
import Header from "./components/Header";
import Footer from "./components/Footer";
import AppRoutes from "./Routes/Routes";
// import { useEffect } from "react";
import { setLogin } from "./redux/slices/loginSlice";
import { useDispatch } from "react-redux";
import { useEffect } from "react";
import { tokenValidation } from "./api/axios/core";

function App() {
  const dispatch = useDispatch();
  // const { isLogin } = useSelector((state) => state.loginSlice);
  useEffect(() => {
    tokenValidation(() => {
      dispatch(setLogin(true));
    });
  });

  return (
    <div>
      <Header />
      <AppRoutes />
      <Footer />
    </div>
  );
}

export default App;
